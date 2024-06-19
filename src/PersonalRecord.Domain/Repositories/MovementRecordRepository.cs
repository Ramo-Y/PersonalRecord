namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MovementRecordRepository : IMovementRecordRepository
    {
        private readonly PersonalRecordContext _context;
        private readonly ILogger<MovementRecordRepository> _logger;

        public MovementRecordRepository(PersonalRecordContext context, ILogger<MovementRecordRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddMovementRecordAsync(MovementRecord movementRecord)
        {
            await _context.MovementRecordItems.AddAsync(movementRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<MovementRecord> GetMovementRecordByIdAsync(Guid movementRecordID)
        {
            var movementRecord = await _context.MovementRecordItems.SingleOrDefaultAsync(m => m.MovementRecordID == movementRecordID);
            return movementRecord;
        }

        public async Task<IEnumerable<MovementRecord>> GetAllMovementRecordsAsync()
        {
            var movementRecordItems = await _context.MovementRecordItems.ToListAsync();
            return movementRecordItems;
        }

        public async Task UpdateAllEntriesAsync(IEnumerable<MovementRecord> movementRecords)
        {
            foreach (var movementRecord in movementRecords)
            {
                _context.MovementRecordItems.Update(movementRecord);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovementRecordAsync(MovementRecord movementRecord)
        {
            try
            {
                var record = await _context.MovementRecordItems.SingleOrDefaultAsync(r => r.MovementRecordID == movementRecord.MovementRecordID);
                if (record != null)
                {
                    _context.MovementRecordItems.Remove(record);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}