namespace ExamMeAI.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Questions> Questions { get; set; } = new List<Questions>();

    }
}
