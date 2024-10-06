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
        public void GetAppVersion_CheckString_ContainsNumbers()
        {
            // arrange
            var appVersion = _versionService.GetAppVersion();
            const int START_INDEX_FOR_NUMBER = 1;

            // act
            var numerString = appVersion[START_INDEX_FOR_NUMBER].ToString();
            var isInt = int.TryParse(numerString, out var number);

            // assert
            Assert.True(isInt, $"The version info '{appVersion}' should start with a number");
        }

        [Fact]
        public void GetAppVersion_CheckString_IsNotEmpty()
        {
            // arrange
            var appVersion = _versionService.GetAppVersion();

            // act
            var isNotEmpty = !string.IsNullOrEmpty(appVersion);

            // assert
            Assert.True(isNotEmpty, $"The version info '{appVersion}' should not be empty");
        }

        [Fact]
        public void GetCommitHash_CheckString_DoesntContainPlus()
        {
            // arrange
            var commitHash = _versionService.GetCommitHash();

            // act
            var containsPlus = commitHash.Contains(PLUS);

            // assert
            Assert.False(containsPlus, $"The informational version info '{commitHash}' should contain a '{PLUS}'");
        }

        [Fact]
        public void GetCommitHash_CheckString_Has40Characters()
        {
            // arrange
            var commitHash = _versionService.GetCommitHash();
            const int COMMIT_HASH_LENGTH = 40;

            // act
            var hashLength = commitHash.Length;

            // assert
            Assert.True(hashLength.Equals(COMMIT_HASH_LENGTH), $"The commit hash '{commitHash}' should have a length of {COMMIT_HASH_LENGTH} characters, but actually has {hashLength}");
        }

        [Fact]
        public void GetInformationalVersion_CheckString_IsNotEmpty()
        {
            // arrange
            var informationalVersion = _versionService.GetInformationalVersion();

            // act
            var isNotEmpty = !string.IsNullOrEmpty(informationalVersion);

            // assert
            Assert.True(isNotEmpty, $"The informational version info '{informationalVersion}' should not be empty");
        }

        [Fact]
        public void GetInformationalVersion_CheckString_ContainsPlusAndVersionNumber()
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