namespace ExamMeAI.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Questions> Questions { get; set; } = new List<Questions>();
        public ICollection<Exams> Exams { get; set; } = new List<Exams>();
        public ICollection<UserActivity> UserActivity { get; set; } = new List<UserActivity>();

    }
}
