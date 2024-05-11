using FluentAssertions;
using Xunit;

namespace TtrpgManagerBackend.Application.Tests.Auth
{
    public class WhenLoggingIn : AuthServiceTestBase
    {
        [Fact]
        public async Task ServiceReturnsResponseWithMessageAndNullDataIfUserDoesNotExist()
        {
            SetUpUserRepositoryMock();

            var response = await LogIn();

            response.Data.Should().BeNull();
            response.Success.Should().BeFalse();
        }
        
        [Fact]
        public async Task ServiceReturnsResponseWithTokenIfCredentialsAreCorrect()
        {
            const int UserId = 1;
            byte[] passwordHash = { 1 };
            byte[] passwordSalt = { 1 };
            string token = Faker.Random.Replace("***.***.***");
            SetUpUserRepositoryMock(UserId, passwordHash, passwordSalt);
            SetUpAuthProviderMock(token: token);

            var response = await LogIn();

            response.Data!.Should().Be(token);
            response.Success.Should().BeTrue();
        }
        
        [Fact]
        public async Task ServiceReturnsResponseWithMessageAndNullDataIfCredentialsAreNotCorrect()
        {
            const int UserId = 1;
            byte[] passwordHash = { 1 };
            byte[] passwordSalt = { 1 };
            SetUpUserRepositoryMock(UserId, passwordHash, passwordSalt);
            SetUpAuthProviderMock(false);

            var response = await LogIn();

            response.Data!.Should().BeNull();
            response.Success.Should().BeFalse();
        }
    }
}