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
Primary keys of a table have a suffix `ID` after the table name. For example, the table `Movement` has the field `MovementID` as GUID.
