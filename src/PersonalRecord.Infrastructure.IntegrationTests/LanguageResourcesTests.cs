namespace PersonalRecord.Infrastructure.IntegrationTests
{
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class Tests
    {
        private const string DEFAULT_LANGUAGE_RESOURCE_FILENAME = "AppResources.resx";

        private const string APP_RESOURCES = "AppResources";

        private const string APP_RESOURCES_FILE_ENDING = "resx";

        private const int LANGUAGE_CODE_LENGTH = 2;

        private List<string> GetLanguageResourceFiles()
        {
            var files = Directory.GetFiles(@"..\..\..\..\PersonalRecord.Infrastructure\Resources\Languages\", "*.resx").ToList();
            return files;
        }

        [Test]
        public void GetAllLanguageFiles_CheckNamingConvention_NamingIsCorrect()
        {
            var files = GetLanguageResourceFiles();

            var defaultFileErrorMessage = $"There should be a file called '{DEFAULT_LANGUAGE_RESOURCE_FILENAME}', it actually doesn't exist";
            Assert.That(files.Any(f => Path.GetFileName(f).Equals(DEFAULT_LANGUAGE_RESOURCE_FILENAME)), defaultFileErrorMessage);
            
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                if (fileName == DEFAULT_LANGUAGE_RESOURCE_FILENAME)
                {
                    continue;
                }

                var parts = fileName.Split('.');
                var appResourcesPart = parts[0];
                var appResourcesPartErrorMessage = $"Language resource file name has to start with '{APP_RESOURCES}', actual one is '{appResourcesPart}'";
                Assert.That(appResourcesPart, Is.EqualTo(APP_RESOURCES), appResourcesPartErrorMessage);

                var languageCodePart = parts[1];
                var languageCodeErrorMessage = $"Language code should be {LANGUAGE_CODE_LENGTH} characters string, actual one is named '{languageCodePart}'";
                Assert.That(languageCodePart.Length, Is.EqualTo(LANGUAGE_CODE_LENGTH), languageCodeErrorMessage);

                var fileEndingPart = parts[2];
                var fileEndingPartErrorMessage = $"The language resource file name has to end with '{APP_RESOURCES_FILE_ENDING}', actual is '{fileEndingPart}'";
                Assert.That(fileEndingPart, Is.EqualTo(APP_RESOURCES_FILE_ENDING), fileEndingPartErrorMessage);
            }
        }
    }
}