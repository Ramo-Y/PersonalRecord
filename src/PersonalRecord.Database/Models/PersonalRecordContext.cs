namespace PersonalRecord.Database.Models
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