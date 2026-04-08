using System.ComponentModel.DataAnnotations;

namespace ExamMeAI.Providers
{
    public class AuthenticatedUser
    {
        public String _name { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public String _password { get; set; }

        [Required]
        [EmailAddress]
        public String _email { get; set; }
        public String _role { get; set; }
        public bool _rememberMe { get; set; }

        private static readonly List<( string Email , string Password, string Name, string Role)> _users = new()
        {
            ("admin@email.com", "admin123", "admin", "Administrator"),
            ("user@email.com", "user123", "user", "guest")
        };

        public AuthenticatedUser() { }
        public AuthenticatedUser(String email, String password, String name, String role)
        {
            _name = name;
            _password = password;
            _email = email;
            _role = role;
        }

        public AuthenticatedUser Authenticate(String email, String password)
        {
            var result = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return result != default ? new AuthenticatedUser(result.Email, result.Password, result.Name, result.Role) : null;
        }
    }
}
