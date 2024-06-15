namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovementRecordRepository : IMovementRecordRepository
    {
        private readonly PersonalRecordContext _context;

        public MovementRecordRepository(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task AddMovementRecordAsync(MovementRecord movementRecord)
        {
            await _context.MovementRecordItems.AddAsync(movementRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovementRecord>> GetAllMovementRecordsAsync()
        {
            var movementRecordItems = await _context.MovementRecordItems.ToListAsync();
            return movementRecordItems;
        }

        public async Task DeleteMovementRecordAsync(MovementRecord movementRecord)
        {
            await _context.MovementRecordItems.Where(m => m.MovementRecordID == movementRecord.MovementRecordID).ExecuteDeleteAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}