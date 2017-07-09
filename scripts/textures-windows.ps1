param (
    $magick = 'magick'
)

$ErrorActionPreference = 'Stop'

Push-Location "$PSScriptRoot/.."
try {
    & $magick convert -background none textures/builder.svg MarsBaseBuilder/resources/builder.png
    & $magick convert -background none textures/cursor.svg -resize 32x32 MarsBaseBuilder/resources/cursor.png
} finally {
    Pop-Location
}
