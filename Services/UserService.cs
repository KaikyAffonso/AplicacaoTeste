using AplicacaoTeste.Models;

namespace AplicacaoTeste.Services
{
    public class UserService
    {


        private List<User> users = new List<User>();
        private int nextId = 1;

        public UserService()
        {
            users.Add(new User
            {
                Id = nextId++,
                Username = "admin",
                Password = "123",
                Role = "Admin",
                Status = UserStatus.Active
            });
        }

        public List<User> GetAll() => users;

        public void Register(string username, string password)
        {
            users.Add(new User
            {
                Id = nextId++,
                Username = username,
                Password = password,
                Role = "User",
                Status = UserStatus.Pending
            });
        }


        public void Approve(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null) return;

            user.Status = UserStatus.Active;
        }

        public User Authenticate(string username, string password)
        {
            var user = users.Find(u =>
                u.Username == username &&
                u.Password == password);

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
