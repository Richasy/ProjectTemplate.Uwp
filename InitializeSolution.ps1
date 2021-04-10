
$solutionPath = Read-Host "Enter solution path"

if ($solutionPath.Length -eq 0) {
    $solutionPath = "."
}
function MoveConfig {
    [CmdletBinding()]
    param (
        [Parameter()]
        [string]
        $fileName,

        [Parameter()]
        [string]
        $subPath
    )
    if($subPath.Length -gt 0) {
        Write-Debug "Creating folder: $subPath"
        New-Item -Path "$solutionPath\$subPath" -ItemType Directory -Force
    }

    $output = "$solutionPath\$subPath$filename"

    Write-Host "Copying $fileName ..."
    Copy-Item "RichasyConfig\$fileName" $output -Force
}

MoveConfig -fileName '.editorconfig'
MoveConfig -fileName '.gitmodules'
MoveConfig -fileName '.gitignore'
MoveConfig -fileName '.gitattributes'
MoveConfig -fileName 'Directory.Build.props'
MoveConfig -fileName 'App.ruleset'
MoveConfig -fileName 'Settings.XamlStyler' -subPath 'src\'
MoveConfig -fileName 'TestUtils.targets'
MoveConfig -fileName 'UnitTests.targets'
MoveConfig -fileName 'Uwp.props'
MoveConfig -fileName 'Uwp.UnitTests.props'
MoveConfig -fileName 'stylecop.json'
MoveConfig -fileName 'xunit.runner.json' -subPath 'src\Shared\'
MoveConfig -fileName 'SharedAssemblyInfo.cs' -subPath 'src\Shared\'
MoveConfig -fileName 'updateSubModules.ps1' -subPath 'tools\'

Write-Host -BackgroundColor Green "Success"
"Any key to exit."
[Console]::Readkey() |　Out-Null
Exit
