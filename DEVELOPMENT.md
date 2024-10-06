- [Description](#description)
- [Documentation](#documentation)
- [Branches](#branches)
  - [Version](#version)
- [Workflows](#workflows)
  - [Secrets and variables](#secrets-and-variables)
    - [Secrets](#secrets)
    - [Variables](#variables)
- [Database](#database)
  - [Migrations](#migrations)
    - [Migrations Repository](#migrations-repository)
  - [Database fields](#database-fields)
    - [Primary key](#primary-key)
    - [All fields](#all-fields)
    - [Foreign Keys](#foreign-keys)
- [Languages](#languages)
  - [Resource file](#resource-file)
    - [Integration Tests](#integration-tests)
  - [Language enum](#language-enum)
  - [Map the language to a culture](#map-the-language-to-a-culture)


# Description
You are welcome to participate in the development of this tool, in this file some information and rules for the development are described.

# Documentation
If changes are made to the interface or functionality, the screenshots and documentation should also be updated.

# Branches
To contribute, please create a fork of the repository, work on the develop branch and create a pull request in the `develop` branch. Once ci has run successfully with the tests, it can be merged into the `develop` branch. As soon as a new version is to be made available, the version is set and the `develop` branch is merged into the `master` branch.

## Version
The versioning of the app is set in the `DisplayVersion` (e.g. 1.0.25) and also the `ApplicationVersion` (e.g. 25) in the file [Directory.Build.props](./src/Directory.Build.props). Once the application has been published on the Play Store, it is no longer possible to republish it with the same `ApplicationVersion`.

# Workflows
The workflows are described in the following table:

| Workflow | File name                                                          				| Trigger                                                                      | Description                                              |
|----------|------------------------------------------------------------------------------------|------------------------------------------------------------------------------|----------------------------------------------------------|
| ci       | [build-test-cleanup.yml](./.github/workflows/build-test-cleanup.yml)               | Commits to any branch except master, and pull requests to develop and master | Builds and tests the software                            |
| release  | [test-build-upload-cleanup.yml](./.github/workflows/test-build-upload-cleanup.yml) | Commits or merges to master                                                  | Builds, tests and publishes the app to Google Play Store |

## Secrets and variables
To publish this app on the play store, you need first to create a [keystore](https://learn.microsoft.com/en-us/dotnet/maui/android/deployment/publish-google-play?view=net-maui-8.0) and upload your signing key to [Google Play Console](https://developer.android.com/studio/publish/app-signing#sign_release). You also need a Google Service Account, that has the permission to upload app bundles, check out [this guide](https://support.readyeducation.com/hc/en-us/articles/360047693573-Google-Play-Service-Account-Setup) to create this account.

### Secrets
The secrets are described in the following table:

| Name                       | Type   | Description                                                                                            |
|----------------------------|--------|--------------------------------------------------------------------------------------------------------|
| KEYSTORE_ALIAS             | Secret | A label for specific key within a keystore                                                             |
| KEYSTORE_BASE64            | Secret | Encode your keystore                                                                                   |
| KEYSTORE_FILENAME          | Secret | File name of your keystore                                                                             |
| KEYSTORE_PASSWORD          | Secret | The password of your key store                                                                         |
| PLAY_STORE_SERVICE_ACCOUNT | Secret | The Google service account JSON                                                                        |
| SYNCFUSION_LICENSE         | Secret | The Snycfusion license you have to apply for [here](https://www.syncfusion.com/sales/communitylicense) |

### Variables
The variables are described in the following table:

| Name                		| Value                                                                                                     	| Description                                                                                                                              |
|---------------------------|---------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| AAB_NAME            		| com.ramo.personalrecord-Signed.aab                                                                        	| Name of the signed AAB file that will be uploaded to Google Play Store                                                                   |
| APP_NAME            		| PersonalRecord.App                                                                                        	| Folder name of the startup project                                                                                                       |
| APP_PROJECT         		| src\PersonalRecord.App\PersonalRecord.App.csproj                                                          	| Startup project path                                                                                                                     |
| BUILD_CONFIGURATION 		| Release                                                                                                   	| Build configuration that will be used the dotnet publish command                                                                         |
| PACKAGE_NAME        		| com.ramo.personalrecord                                                                                 		| Package name that will be published to Google Play Store                                                                                 |
| TARGET_FRAMEWORK    		| net8.0-android                                                                                           		| Target framework that will be used for .NET MAUI deployment                                                                              |
| UNIT_TEST_PROJECTS		| src\PersonalRecord.Services.UnitTests\ PersonalRecord.Services.UnitTests.csproj 								| Relative path of the unit test projects, space separated 												   						 		 |
| INTEGRATION_TEST_PROJECTS | src\PersonalRecord.Infrastructure.IntegrationTests\ PersonalRecord.Infrastructure.IntegrationTests.csproj 	| Relative path of the integration test projects, space separated                                                                          |
| WHATS_NEW_DIRECTORY 		| .dist/whatsnew                                                                                            	| Folder that contains the what's new files (see [documentation](https://github.com/r0adkll/upload-google-play?tab=readme-ov-file#inputs)) |

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

# Languages
A new language can be added very easily, you need Visual Studio, you can download it [here](https://visualstudio.microsoft.com/downloads/). In this example, we will add `Spanish` as a new language.

## Resource file
Create a new resource file in the folder [Languages](./src/PersonalRecord.Infrastructure/Resources/Languages) and provide your language code between the file name `AppResources` and the extension `resx`, for example `AppResources.es.resx`. Copy all the keys from the [default language file](./src/PersonalRecord.Infrastructure/Resources/Languages/AppResources.resx) which is English, and add the translations. Check out this [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/localization?view=net-maui-8.0#create-resource-files-to-store-strings) to learn more about resource files.

### Integration Tests
There are a few integration tests, that will ensure that all the language keys, that exist in the English version, have also been translated to the new language. Please run [these tests](./src/PersonalRecord.Infrastructure.IntegrationTests/Resources/Languages/LanguageResourcesTests.cs) before creating a pull request.

## Language enum
Extend the [Language enum](./src/PersonalRecord.Infrastructure/Language.cs) with your language name that will be displayed on the settings page e.g. `Spanish`.

## Map the language to a culture
Go to the class [App.xaml.cs](./src/PersonalRecord.App/App.xaml.cs) and register your language withing the method `SetLanguage()` with the corresponding culture.

```c#
culture = settings.Language switch
{
    Infrastructure.Language.English => "en-US",
    Infrastructure.Language.German => "de-DE",
    // Map your new language here like this one
    Infrastructure.Language.Spanish => "es-ES",
    _ => "en-US",
};
```
