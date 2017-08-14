1969 [![Status Zero][status-zero]][andivionian-status-classifier] [![Appveyor build status][appveyor-status]][appveyor] [![Travis build status][travis-status]][travis]
====

> The Moon landing never happened, but we went to the Mars instead.

In 1969, you control the robotic mining mission on Mars.

![Game screenshot][screenshot]

Documentation
-------------

There's a [game design document][docs-game-design] available.

Build
-----

### Windows

Either use [Visual Studio][visual-studio] to open and build `MoonBaseBuilder.sln`
file, or invoke the following commands in developer console:

```console
$ nuget restore
$ msbuild
$ fsi scripts/deps-downloader.fsx win
```

### Linux

You'll need [Mono][mono] and [NuGet][nuget] installed.

```console
$ nuget restore
$ xbuild
$ fsi scripts/deps-downloader.fsx linux
```

Also you should download [SDL2 dependencies][monogame-sdl] for your platform.

#### NixOS

There's a ready nix-shell environment in `default.nix`. Just invoke the
following:

```console
$ nix-shell
$ nuget restore
$ xbuild
```

Requires NixOS 16.09+.

#### macOS

You'll need [Mono][mono] and [NuGet][nuget] installed.

Currently, we recommend to build the project using [JetBrains Rider][jetbrains-rider].
Open and build `MoonBaseBuilder.sln` file,
then invoke the following command in the terminal:

```console
$ fsi scripts/deps-downloader.fsx macOS
```

Run
---

To run the game on Windows, execute the following commands:

```console
> cd MarsBaseBuilder\bin\Debug
> .\MarsBaseBuilder.exe
```

On Linux or macOS:

```console
$ cd MarsBaseBuilder/bin/Debug
$ mono ./MarsBaseBuilder.exe
```

Textures
--------

There're processed textures in the game repository. Although, if you want to
process the textures again, run the following command (requires
[imagemagick][]):

```console
$ magick convert -depth 8 -background none textures/builder.svg MarsBaseBuilder/resources/builder.png
$ magick convert -resize 32x32 -depth 8 -background none textures/cursor.svg MarsBaseBuilder/resources/cursor.png
```

There's a script to do that on Windows; see `script/textures-windows.ps1` and
don't forget to check its' parameters.

License
-------

All the source code of this project is distributed under the MIT license. Check
[License.md][license] for more information.

All the accompanying image files are licensed under a [Creative Commons
Attribution 4.0 International License][cc-by-license].

[docs-game-design]: docs/game-design.md
[license]: License.md

[screenshot]: docs/screenshot.png

[andivionian-status-classifier]: https://github.com/ForNeVeR/andivionian-status-classifier#status-zero-
[appveyor]: https://ci.appveyor.com/project/ForNeVeR/1969/branch/master
[cc-by-license]: https://creativecommons.org/licenses/by/4.0/
[imagemagick]: https://www.imagemagick.org/script/index.php
[mono]: http://www.mono-project.com/
[monogame-sdl]: https://github.com/MonoGame/MonoGame.Dependencies/tree/master/SDL
[nuget]: https://www.nuget.org/
[travis]: https://travis-ci.org/ForNeVeR/1969
[visual-studio]: https://www.visualstudio.com/
[jetbrains-rider]: https://www.jetbrains.com/rider/
[xunit]: https://xunit.github.io/

[appveyor-status]: https://ci.appveyor.com/api/projects/status/n0bi5bm1uwd8irwh/branch/master?svg=true
[status-zero]: https://img.shields.io/badge/status-zero-lightgrey.svg
[travis-status]: https://travis-ci.org/ForNeVeR/1969.svg?branch=master
