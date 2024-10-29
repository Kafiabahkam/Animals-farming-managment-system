using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animals_farming_managment_system.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string HealthStatus { get; set; }
        public List<FeedingSchedule> FeedingSchedules
        {
            get; set;
        }
        public List<HealthRecord> HealthRecords { get; set; }
        [Required]
        public int BarnId { get; set; }
        public Barn Barn { get; set; }
    }
}
