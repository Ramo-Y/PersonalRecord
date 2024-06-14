namespace PersonalRecord.Domain.Models.Entities
{
    using Microsoft.EntityFrameworkCore;

    public class PersonalRecordContext : DbContext
    {
        public PersonalRecordContext(DbContextOptions<PersonalRecordContext> options)
            : base(options)
        {
        }
    }
}