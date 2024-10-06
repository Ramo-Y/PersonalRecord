namespace PersonalRecord.Services.UnitTests
{
    using PersonalRecord.Services.Interfaces;

    public class VersionServiceTests
    {
        private readonly IVersionService _versionService;

        private const char PLUS = '+';

        public VersionServiceTests(IVersionService versionService)
        {
            _versionService = versionService;
        }

        [Fact]
        public void GetAppVersion_IsNotEmpty()
        {
            // arrange
            var appVersion = _versionService.GetAppVersion();

            // act
            var isNotEmpty = !string.IsNullOrEmpty(appVersion);

            // assert
            Assert.True(isNotEmpty, $"The version info '{appVersion}' should not be empty");
        }

        [Fact]
        public void GetInformationalVersion_IsNotEmpty()
        {
            // arrange
            var informationalVersion = _versionService.GetInformationalVersion();

            // act
            var isNotEmpty = !string.IsNullOrEmpty(informationalVersion);

            // assert
            Assert.True(isNotEmpty, $"The informational version info '{informationalVersion}' should not be empty");
        }

        [Fact]
        public void GetInformationalVersion_HasVersionNumberAndPlus()
        {
            // arrange
            var informationalVersion = _versionService.GetInformationalVersion();

            // act
            var numberString = informationalVersion[0].ToString();
            var isInt = int.TryParse(numberString, out var number);
            var containsPlus = informationalVersion.Contains(PLUS);

            // assert
            Assert.True(containsPlus, $"The informational version info '{informationalVersion}' should contain a '{PLUS}'");
            Assert.True(isInt, $"The informational version info '{informationalVersion}' should start with a number but actually starts with '{numberString}'");
        }
    }
}