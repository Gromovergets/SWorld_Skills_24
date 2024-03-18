using TestPro.Models2;

namespace TestPro.Repository
{
    public interface IRepository
    {
        ICollection<User> GetAllUsers();
        Task<User> GetById(int id);
        Task Save();
    }
}
