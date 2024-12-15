namespace mvc.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string StudentId { get; set; }

        public Student student { get; set; }
        public Event Event { get; set; }
    }
}