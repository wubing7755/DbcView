---
name: Infrastructure request
about: Propose build, CI, dependency, testing, or tooling maintenance
title: "infra: "
labels: infrastructure
assignees: ""
---

## Scope

Describe the build, CI, dependency, testing, or tooling change.

## Affected Area

- [ ] Build (MSBuild / dotnet CLI)
- [ ] CI / GitHub Actions
- [ ] Testing (xUnit / coverlet)
- [ ] Dependencies (NuGet)
- [ ] Documentation
- [ ] Repository layout / tooling

## Motivation

Describe the maintenance risk, workflow gap, or quality issue.

## Validation

List checks that should prove the change works.

```sh
dotnet build
dotnet test
```

## Risk Or Rollback

Describe the risk, compatibility concern, or rollback path.
