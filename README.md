# DbcView

`DbcView` is a standalone Blazor WebAssembly application for browsing and
editing CAN database (DBC) files. It is built on the
[Atlas](https://github.com/wubing7755/Atlas) dock layout component library,
consuming the published `Atlas.Blazor` NuGet package — it never references
Atlas source projects.

## Features

- DBC file explorer with folder / file tree (sample files are bundled under
  `samples/`)
- DBC editor with message and signal tables
- Properties panel for messages and signals
- Dockable tool panels, document tabs, splitters, and layout persistence
  provided by Atlas

## Live demo

A GitHub Pages deployment of the application is available at
<https://wubing7755.github.io/DbcView/>. Pushes to `main` rebuild and
deploy it through `.github/workflows/deploy.yml`.

## Build from the repository

Requires .NET 6 SDK. The project restores `Atlas.Blazor` from nuget.org:

```powershell
dotnet restore DbcView.sln --configfile NuGet.Config
dotnet build DbcView.sln --no-restore
dotnet test DbcView.sln --no-build --no-restore
dotnet run --project src/DbcView/DbcView.csproj --no-restore
```

Open the URL printed by `dotnet run`. The app references the Atlas RCL
stylesheet through `_content/Atlas.Blazor/atlas-v2/atlas.css`; it does not
copy Atlas JavaScript or CSS sources.

> **Local Atlas packages (optional):** to test against unpublished Atlas
> builds, uncomment the `atlas-local` source in `NuGet.Config` and point it at
> a feed containing `Atlas.Core` and `Atlas.Blazor` (for example the Atlas
> repository's `artifacts/packages`). Update the version in
> `Directory.Packages.props` when needed.

## Sample DBC data

`samples/bmw_e9x_e8x.dbc` is a community-maintained CAN database file for
BMW E9x/E8x vehicles, sourced from
<https://github.com/dzid26/opendbc-BMW-E8x-E9x> (MIT licensed; see the
`CM_ "License MIT"` comment in the file header). The file is used only as
sample data for the DBC explorer and is copied to the test output for the
parser tests.

## Design notes

- The project intentionally contains no project-to-project references, linked
  Atlas source files, internal APIs, or test helpers — the same consumer
  boundary that Atlas's own sample enforced is preserved here, and
  `tests/DbcView.Tests/DemoPackageBoundaryTests.cs` verifies it.
- The Atlas six-region toolbar layout from the original Atlas consumer sample
  is kept so the app doubles as a live consumer showcase of the Atlas
  component library.
