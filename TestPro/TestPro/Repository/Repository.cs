using Microsoft.EntityFrameworkCore;
using TestPro.Models2;

namespace TestPro.Repository
{
    public class Repository : IRepository
    {
        private readonly HospitalContext _context;
        public Repository(HospitalContext con)
        {
            using (var context = new HospitalContext())
            {
                
                context.Entry(entity).Reload(); // обновляем данные объекта из базы данных
            }
            _context = con;

        }
        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
