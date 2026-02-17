using DevcardResume.Data.Models;

namespace DevcardResume.Data.Repo
{
    public interface IPerRepo
    {
        Task<IEnumerable<People>> GetPersonAsync();
    }
}
