namespace PersonalRecord.Domain.Models
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Models.Entities;

    public class PreparationDatabase
    {
        private readonly PersonalRecordContext _context;

        public PreparationDatabase(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task PreparatePopulation()
        {
            await _context.Database.MigrateAsync();
        }
    }
}