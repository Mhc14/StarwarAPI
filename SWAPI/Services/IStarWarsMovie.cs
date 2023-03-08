using SWAPI.Models;

namespace SWAPI.Services
{
    public interface IStarWarsMovie
    {
         Task<ResponseSW> GetPublicStarWarsMovie(int Pagenumber);
        Task<ResponseDownload> GetProtectedStarWarsMovie(int Pagenumber);
    }
}
