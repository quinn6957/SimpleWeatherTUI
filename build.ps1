# IMPORTANT!!!
# This script is designed for Windows, Linux, or macOS with PowerShell installed.
# It performs self-contained .NET 9 project builds for various platforms.

Write-Host "Building SimpleWeatherTUI for Linux (x64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r linux-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\linux-x64"

Write-Host "Building SimpleWeatherTUI for Linux (arm64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r linux-arm64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\linux-arm64"

Write-Host "Building SimpleWeatherTUI for Windows (x64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\win-x64"

Write-Host "Building SimpleWeatherTUI for Windows (arm64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r win-arm64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\win-arm64"

Write-Host "Building SimpleWeatherTUI for macOS (x64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r osx-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\osx-x64"

Write-Host "Building SimpleWeatherTUI for macOS (arm64)..." -ForegroundColor Green
dotnet publish -c Release --self-contained true -r osx-arm64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true --output ".\publish\osx-arm64"

Write-Host "Build process completed." -ForegroundColor Green
