using System.ComponentModel.DataAnnotations;

namespace Animals_farming_managment_system.Models
{
    public class FeedingSchedule
    {
        public int Id { get; set; }


        public string FeedType { get; set; }
        public double Quantity { get; set; }
        public DateTime FeedingTime { get; set; }
        [Required]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
