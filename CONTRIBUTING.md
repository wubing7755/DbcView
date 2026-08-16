# Contributing

DbcView is a standalone Blazor WebAssembly application for browsing and
editing CAN database (DBC) files. It is also the consumer showcase for the
[Atlas](https://github.com/wubing7755/Atlas) dock layout component library:
it consumes the published `Atlas.Blazor` NuGet package from nuget.org and
never references Atlas source projects.

## Consumer Boundary

- The only dependency on Atlas is the published `Atlas.Blazor` NuGet package;
  `Atlas.Core` is embedded in that package (single-package distribution).
- The repository keeps **no project-to-project references**: the test project
  references the built `DbcView.dll` by `HintPath`, not by `ProjectReference`.
  `tests/DbcView.Tests/DemoPackageBoundaryTests.cs` verifies the boundary.
- Do not add linked Atlas source files, internal APIs, or test helpers.

## Documentation Language

English is the canonical documentation language.

## Local Checks

```sh
# Restore .NET dependencies
dotnet restore DbcView.sln --configfile NuGet.Config

# Build all projects
dotnet build DbcView.sln --no-restore

# Run all tests
dotnet test DbcView.sln --no-build --no-restore

# Check code style
dotnet format DbcView.sln --verify-no-changes --no-restore
```

## Branches

Use short branch names:

- `feature/<topic>`
- `fix/<topic>`
- `refactor/<topic>`
- `infra/<topic>`

## Commits And PRs

Use Conventional Commit style:

```text
feat(editor): add signal editing
fix(parser): handle multiplexed messages
refactor(store): extract DbcDocument loading from DbcFileStore
infra(ci): add format verification job
docs(readme): document repository layout
```

Before opening a PR:

- Run the Local Checks above.
- Run `dotnet format` to ensure consistent code style.
- Fill in the PR template sections that apply to the change.
- Add tests for behaviour changes.
- Keep unrelated cleanup out of feature or fix PRs.

Use the issue templates for bug reports, feature proposals, and
infrastructure maintenance requests.

## Architecture

- DBC parsing, document models, and persistence live under `src/DbcView`
  (`Services/`, `Models/`, `ViewModels/`).
- Razor components live under `src/DbcView/Components/` and pages under
  `src/DbcView/Pages/`.
- Sample DBC data lives in `samples/` and is copied to the test output for
  the parser tests.
