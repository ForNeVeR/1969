param (
    $magick = 'magick'
)

$ErrorActionPreference = 'Stop'

Push-Location "$PSScriptRoot/.."
try {
    & $magick convert -depth 8 -background none textures/builder.svg MarsBaseBuilder/resources/builder.png
    & $magick convert -resize 32x32 -depth 8 -background none textures/cursor.svg MarsBaseBuilder/resources/cursor.png
} finally {
    Pop-Location
}
