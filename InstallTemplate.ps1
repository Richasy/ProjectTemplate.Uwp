
Function FindVisualStudioUserFolders()
{
    $userFolder = [environment]::GetFolderPath("mydocuments")
    Return Get-ChildItem $userFolder -Directory -Filter "visual studio *"
}

Function PackageAndDeployTemplate([System.IO.DirectoryInfo]$visualStudioUserFolder, [String]$projectName)
{
    try
    {
        Write-Host "Installing template to " -NoNewline
        Write-Host $visualStudioUserFolder.FullName -NoNewLine -ForegroundColor DarkGray
        $projectSourceFolderPath = Join-Path $PSScriptRoot $projectName
        $packageFilesSelector = Join-Path $projectSourceFolderPath "*"
        $packageDestinationFolder = Join-Path $visualStudioUserFolder.FullName "Templates\ProjectTemplates\Visual C#\Richasy"
        $packageDestinationFile = Join-Path $packageDestinationFolder $projectName

        # Creating target folder
        New-Item -ItemType Directory -Force -Path $packageDestinationFolder > $null

        # Zipping and copying to the project template folder
        Compress-Archive -Path $packageFilesSelector -DestinationPath $packageDestinationFile -Force #no need to specify the extension

        Write-Host " Done" -ForegroundColor Green
    }
    catch
    {
        Write-Host " Failed" -ForegroundColor Red
        Write-Host $_.Exception.Message -ForegroundColor Yellow
    }
}

$visualStudioUserFolders = FindVisualStudioUserFolders;

foreach ($userFolder in $visualStudioUserFolders)
{
    PackageAndDeployTemplate $userFolder "RichasyModule"
    PackageAndDeployTemplate $userFolder "RichasyUwpAdapter"
    PackageAndDeployTemplate $userFolder "RichasyUwpApp"
}