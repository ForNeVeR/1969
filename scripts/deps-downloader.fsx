open System.IO
open System.Net

let baseUrl = "https://github.com/MonoGame/MonoGame.Dependencies/raw/master/SDL"
let debugPath = Path.Combine(__SOURCE_DIRECTORY__, "../MarsBaseBuilder/bin/Debug/")
let releasePath = Path.Combine(__SOURCE_DIRECTORY__, "../MarsBaseBuilder/bin/Release/")
let bits = if System.Environment.Is64BitOperatingSystem then "x64" else "x86"

let fileDownloader (url : string) (fileName : string) =
    use client = new WebClient()
    let download path =
        if Directory.Exists path
        then client.DownloadFile(url, Path.Combine(path, fileName))
        else printfn "Error: %s does not exists" path

    download debugPath
    download releasePath
    printfn "Dependencies downloaded!"

match fsi.CommandLineArgs.[1] with
| "macOS" ->
    let fileName = "libSDL2-2.0.0.dylib"
    let url = sprintf "%s/MacOS/Universal/%s" baseUrl fileName
    fileDownloader url fileName
| "win" ->
    let fileName = "SDL2.dll"
    let url = sprintf "%s/Windows/%s/%s" baseUrl bits fileName
    fileDownloader url fileName
| "linux" ->
    let fileName = "libSDL2-2.0.so.0"
    let url = sprintf "%s/Linux/%s/%s" baseUrl bits fileName
    fileDownloader url fileName
| other ->
    printfn "Error: unrecognized argument %s" other
