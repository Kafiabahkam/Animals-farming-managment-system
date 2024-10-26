namespace Animals_farming_managment_system.Models
{
    public class Barn
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string CleanlinessStatus { get; set; }

        
        public ICollection<Animal> Animals { get; set; }
    }
}
