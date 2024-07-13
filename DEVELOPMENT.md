# Description
You are welcome to participate in the development of this tool, in this file some information and rules for the development are described.

# Documentation
If changes are made to the interface or functionality, the screenshots and documentation should also be updated.

# Branches
To contribute, please create a fork of the repository, work on the develop branch and create a pull request in the `develop` branch. Once ci has run successfully with the tests, it can be merged into the `develop` branch. As soon as a new version is to be made available, the version is set and the develop branch is merged into the master.

## Version
The versioning of the app is set in the `DisplayVersion` (e.g. 1.0.25) and also the `ApplicationVersion` (e.g. 25) in the file [Directory.Build.props](./src/Directory.Build.props). Once the application has been published on the Play Store, it is no longer possible to republish it with the same `ApplicationVersion`.

# Workflows
The workflows are described in the following table:

| Workflow | File name                                                          | Trigger                                                                      | Description                                              |
|----------|--------------------------------------------------------------------|------------------------------------------------------------------------------|----------------------------------------------------------|
| ci       | [build-test.yml](./.github/workflows/build-test.yml)               | Commits to any branch except master, and pull requests to develop and master | Builds and tests the software                            |
| release  | [test-build-upload.yml](./.github/workflows/test-build-upload.yml) | Commits or merges to master                                                  | Builds, tests and publishes the app to Google Play Store |

# Database

## Migrations
EF Core cannot be used to migrate projects that targets platform Android. The official way is to create a new project with a supported platform and perform the migration there. When adding the migration to this project, the following error appears:
```
Startup project 'PersonalRecord.App' targets platform 'Android'. The Entity Framework Core Package Manager Console Tools don't support this platform. See https://aka.ms/efcore-docs-pmc-tfms for more information.
```

Bug Report on MAUI: https://github.com/dotnet/maui/issues/9940

Documentation of EF Core: https://learn.microsoft.com/en-us/ef/core/cli/powershell#other-target-frameworks

### Migrations Repository
I have created a separate project so that the migrations can be created. The entities can be extended in the project, the migrations can be added, and the result can be copied to this repository.

Checkout this repository for the migrations: https://github.com/Ramo-Y/PersonalRecordMigrations

## Database fields

### Primary key
Primary keys of a table have a suffix `ID` after the table name. For example, the table `Movement` has the field `MovementID` as GUID.

### All fields
All fields except the primary key fields follow a prefix with the shortened 3-letter name of the table. For the table `Movement` we can use `Mov` for the field `MovName`.

### Foreign Keys
Foreign key fields follow the given pattern:
- `Mvr` as the general preffix of the table `MovementRecord`
- `MovementID` same name as the primary key field of the referenced table
- `_FK` as a suffix to highlight that it is a foreign key

So we have a foreign key field named `MvrMovementID_FK`.
