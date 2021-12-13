# libuv-cs

Automatically updated C# bindings for https://github.com/libuv/libuv with native dynamic link libraries.

## How to use

### NuGet packages

1. Install the `bottlenoselabs.uv` NuGet package. This package contains only the C# bindings. To get the pre-release development packages, use the NuGet package feed: `https://www.myget.org/F/bottlenoselabs/api/v3/index.json`.
2. Install one of the following packages which contain the native library for the runtime identifier. More than one these packages can be installed at once if desired but is not strictly required and will waste disk space unnecessarily. 
   -  `bottlenoselabs.uv.runtime.win-x64`: The `uv.dll` native binary for Windows (64-bit).
   -  `bottlenoselabs.uv.runtime.osx`: The `libuv.dylib` for macOS Intel (`osx-x64`) + macOS Apple Silicon (`osx-arm64`).
   -  `bottlenoselabs.uv.runtime.linux-x64`: The `libuv.so` for Linux x64.

### From source

1. Download and install [.NET 6](https://dotnet.microsoft.com/download).
2. Fork the repository using GitHub or clone the repository manually with submodules: `git clone --recurse-submodules https://github.com/bottlenoselabs/libuv-cs`.
3. Build the native library by running `bash ./library.sh`. (Building for Windows requires MSYS2 or Windows Subsystem for Linux with Ubuntu).
4. Add the C# project `./src/cs/production/uv/uv.csproj` to your solution.
5. Add one of the C# shim projects for the native binary in the same way as `uv.csproj`.
   -  `uv.win-x64`: The `uv.dll` native binary for Windows x64.
   -  `uv.osx`: The `libuv.dylib` for macOS Intel (`osx-x64`) + macOS Apple Silicon (`osx-arm64`).
   -  `uv.linux-x64`: The `libuv.so` for Linux x64.

If you wish to re-generate the bindings, simple run `bash ./bindgen.sh`.

## Developers: Documentation

- For more information on how C# bindings work, see [`C2CS`](https://github.com/bottlenoselabs/c2cs), the tool that generates the bindings for `libuv` and other C libraries.
- To learn how to use `libuv`, check out the [libuv's documentation](http://docs.libuv.org).

## License

`libuv-cs` is licensed under the MIT License (`MIT`) - see the [LICENSE file](LICENSE) for details.

`libuv` itself is licensed under MIT License (`MIT`) - see https://github.com/libuv/libuv/blob/v1.x/LICENSE for more details.
