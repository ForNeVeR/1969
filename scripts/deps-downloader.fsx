let baseUrl = "https://github.com/MonoGame/MonoGame.Dependencies/raw/master/SDL"
let debugPathToProjectBin = sprintf "%s/../MarsBaseBuilder/bin/Debug/" __SOURCE_DIRECTORY__
let releasePathToProjectBin = sprintf "%s/../MarsBaseBuilder/bin/Release/" __SOURCE_DIRECTORY__
let bit = if System.Environment.Is64BitOperatingSystem then "x64" else "x86"


let fileDownloader (webClient:System.Net.WebClient) (url:string) (debugPath,releasePath) =
    if System.IO.Directory.Exists(debugPathToProjectBin)
        then webClient.DownloadFile(url,debugPath)
        else printfn "Debug path not found!"

    if System.IO.Directory.Exists(releasePathToProjectBin) 
        then webClient.DownloadFile(url,releasePath)
        else printfn "Release path not found!"
    printfn "Dependencies downloaded!"

match fsi.CommandLineArgs.[1] with
| "macOS" ->
    let fileName = "libSDL2-2.0.0.dylib"
    let url = sprintf "%s/MacOS/Universal/%s" baseUrl fileName
    use wc = new System.Net.WebClient()
    fileDownloader wc url (debugPathToProjectBin + fileName,releasePathToProjectBin + fileName)
| "win" ->
    let fileName = "SDL2.dll"
    let url = sprintf "%s/Windows/%s/%s" baseUrl bit fileName
    use wc = new System.Net.WebClient()
    fileDownloader wc url (debugPathToProjectBin + fileName,releasePathToProjectBin + fileName)
| "linux" ->
    let fileName = "libSDL2-2.0.so.0"
    let url = sprintf "%s/Linux/%s/%s" baseUrl bit fileName
    use wc = new System.Net.WebClient()
    fileDownloader wc url (debugPathToProjectBin + fileName,releasePathToProjectBin + fileName)
| _ -> ()