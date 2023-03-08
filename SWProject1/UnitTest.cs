using Moq;
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
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httClientMock = new Mock<HttpClient>();
            httClientMock.Object.BaseAddress = new Uri("http://swapi.dev/api/people/?page" + "=" + 1);
            httpClientFactoryMock.Setup(_ => _.CreateClient("http://swapi.dev/api/people/?page" + "=" + 1)).Returns(httClientMock.Object);
            var starwarmovie = new StarWarsMovie(httpClientFactoryMock.Object);
            var result = await starwarmovie.GetPublicStarWarsMovie(1);

            // Assert
            Assert.NotNull(result);
        }


        [Test]
        public async Task StarwarMovie_returns_protected_specified_character()
        {

            // ARRANGE
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var httClientMock = new Mock<HttpClient>();
            httClientMock.Object.BaseAddress = new Uri("http://swapi.dev/api/people/?page" + "=" + 1);
            httpClientFactoryMock.Setup(_ => _.CreateClient("http://swapi.dev/api/people/?page" + "=" + 1)).Returns(httClientMock.Object);
            var starwarmovie = new StarWarsMovie(httpClientFactoryMock.Object);
            var result = await starwarmovie.GetProtectedStarWarsMovie(1);

            // Assert
            Assert.NotNull(result);
        }
    }
}