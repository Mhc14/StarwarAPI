using SWAPI.Models;

namespace SWAPI.Services
{
    public interface IStarWarsMovieService
    {
         Task<ResponseSW> GetPublicStarWarsMovie(int Pagenumber);
        Task<ResponseDownload> GetProtectedStarWarsMovie(int Pagenumber);
    }
}
