# Richasy Project Template

This is a UWP project template for personal use. If you want to use it, please follow the steps below:

## How to use

1. Clone the repo and save it in a local folder.
2. Right-click `InstallTemplate.ps1` and select **Run with Powershell**
3. After the template is installed, your Visual Studio can create `Richasy Uwp App`, `Richasy Uwp Adapter` and `Richasy Module`.

- `Richasy Uwp App`: You can create a UWP main application, including basic localized text, theme styles, etc.
- `Richasy Uwp Adapter`: The project type is UWP class library, used to call WinRT API projects. While creating the class library, the corresponding unit test project will be created.
- `Richasy Module`: Based on the .NET Standard 2.0 class library project, three related projects of `Interface`, `Implement` and `UnitTest` will be defined at the same time. In this project, the WinRT API cannot be accessed.

## How to create an application

1. Create a new **Solution** in Visual Studio and place it where you want.
2. Run `DownloadConfig.ps1`, input the solution path, and wait for the download to complete.
3. Create a new `Richasy Uwp App` project in Visual Studio.

***Note. When creating the project, please place it in the `src` folder in the solution folder to ensure correct path resolution.***