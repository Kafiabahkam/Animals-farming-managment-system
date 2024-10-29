using System.ComponentModel.DataAnnotations;

namespace Animals_farming_managment_system.Models
{
    public class HealthRecord
    {
        public int Id { get; set; }
        public DateTime CheckupDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string VetName { get; set; }

        [Required]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }



    }
}
