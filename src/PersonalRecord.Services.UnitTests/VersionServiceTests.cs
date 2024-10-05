namespace PersonalRecord.Services.UnitTests
{
    using PersonalRecord.Services.Interfaces;

    public class VersionServiceTests
    {
        private readonly IVersionService _versionService;

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
    }
}