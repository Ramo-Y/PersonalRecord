namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Movement
    {
        [Key]
        public Guid MovementID { get; set; }

        public string Name { get; set; }
    }
}