<#
.SYNOPSIS
    Download the dependencies for Windows platform.
.PARAMETER X64
    Whether to download the dependencies for x64 version (by default will determine automatically).
.PARAMETER Configuration
    Either 'Release', 'Debug' or 'Both'. Determines the directory where the dependencies will be
    copied.
#>
param (
    [bool] $X64 = [Environment]::Is64BitOperatingSystem,
    [string] $Configuration = 'Both',
    [string] $SolutionPath = "$PSScriptRoot/.."
)

$ErrorActionPreference = 'Stop'

$platform = if ($X64) { 'x64' } else { 'x86' }
[string[]] $outputDirectory = if ($Configuration -eq 'Both') { @('Debug', 'Release') } else { @($Configuration) }

$url = "https://github.com/MonoGame/MonoGame.Dependencies/blob/3aee602ea3dfa338edbf0f16b500cebd48c78da6/SDL/Windows/x64/SDL2.dll?raw=true"
$response = Invoke-WebRequest -UseBasicParsing $url

$outputDirectory | ForEach-Object {
    $dir = $_
    $path = [IO.Path]::Combine($SolutionPath, 'MarsBaseBuilder', 'bin', $dir)
    if (-not (Test-Path $path -PathType Container)) {
        New-Item -ItemType Directory $path
    }

    $stream = New-Object IO.FileStream "$path/SDL2.dll", 'Create'
    $response.RawContentStream.CopyTo($stream)
    $stream.Dispose()
    $response.RawContentStream.Position = 0
}
