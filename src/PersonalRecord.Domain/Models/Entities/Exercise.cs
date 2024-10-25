namespace PersonalRecord.Domain.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Exercise
    {
        [Key]
        public Guid ExerciseID { get; set; }

        public string ExrName { get; set; }
    }
}