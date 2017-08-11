let baseUrl = "https://github.com/MonoGame/MonoGame.Dependencies/raw/master/SDL"
let pathToProjectBin = sprintf "../MarsBaseBuilder/bin/%s" fsi.CommandLineArgs.[2]
let bit = if System.Environment.Is64BitOperatingSystem then "x64" else "x86"
let wc = new System.Net.WebClient()
match fsi.CommandLineArgs.[1] with
    | "macOS" ->
        let url = sprintf "%s/MacOS/Universal/libSDL2-2.0.0.dylib" baseUrl
        let filePath = sprintf "%s/libSDL2-2.0.0.dylib" pathToProjectBin
        wc.DownloadFile(url,filePath)
    | "win" ->
        let url = sprintf "%s/Windows/%s/SDL2.dll" baseUrl bit
        let filePath = sprintf "%s/SDL2.dll" pathToProjectBin
        wc.DownloadFile(url,filePath)
    | "linux" ->
        let url = sprintf "%s/Linux/%s/libSDL2-2.0.so.0" baseUrl bit
        let filePath = sprintf "%s/libSDL2-2.0.so.0" pathToProjectBin
        wc.DownloadFile(url,filePath)
    | _ -> ()