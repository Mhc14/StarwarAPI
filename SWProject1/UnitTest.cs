
using Microsoft.Extensions.Configuration;
using Moq;
using ServiceStack.Text;
using SWAPI.Services;


namespace SWProject1
{
    public class Tests
    {
        public Tests()
        {



        }
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task StarwarMovie_returns_public_specified_character()
        {

            // ARRANGE
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("http://swapi.dev/api/");

            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.Is<string>(k => k == "SWAPIBaseUrl"))).Returns(mockSection.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httClientMock = new Mock<HttpClient>();
            httClientMock.Object.BaseAddress = new Uri("http://swapi.dev/api/");
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httClientMock.Object);
            var starwarmovie = new StarWarsMovieService(httpClientFactoryMock.Object, mockConfig.Object);
            var result = await starwarmovie.GetPublicStarWarsMovie(1);

            //Assert
             Assert.NotNull(result);
        }


        [Test]
        public async Task StarwarMovie_returns_protected_specified_character()
        {


            // ARRANGE
            Mock<IConfigurationSection> mockSection = new Mock<IConfigurationSection>();
            mockSection.Setup(x => x.Value).Returns("http://swapi.dev/api/");

            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection(It.Is<string>(k => k == "SWAPIBaseUrl"))).Returns(mockSection.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httClientMock = new Mock<HttpClient>();
            httClientMock.Object.BaseAddress = new Uri("http://swapi.dev/api/");
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httClientMock.Object);
            var starwarmovie = new StarWarsMovieService(httpClientFactoryMock.Object, mockConfig.Object);
            var result = await starwarmovie.GetProtectedStarWarsMovie(1);

            //Assert
            Assert.NotNull(result);
        }
    }
}