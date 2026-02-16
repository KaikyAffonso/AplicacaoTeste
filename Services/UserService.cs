using AplicacaoTeste.Data;
using AplicacaoTeste.Models;

namespace AplicacaoTeste.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;

            // Criar admin se não existir
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    Username = "admin",
                    Password = "123",
                    Role = "Admin",
                    Status = UserStatus.Active
                });

                _context.SaveChanges();
            }
        }

        public List<User> GetAll() => _context.Users.ToList();

        public void Register(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Role = "User",
                Status = UserStatus.Pending
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Approve(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return;

            user.Status = UserStatus.Active;
            _context.SaveChanges();
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
                return null;

            if (user.Status == UserStatus.Pending)
                throw new Exception("Usuário aguardando aprovação.");

            if (user.Status == UserStatus.Inactive)
                throw new Exception("Usuário inativo.");

            return user;
        }
    }
}
