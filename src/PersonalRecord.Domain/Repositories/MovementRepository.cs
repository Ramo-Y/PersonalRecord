namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;

    public class MovementRepository : IMovementRepository
    {
        private readonly PersonalRecordContext _context;

        public MovementRepository(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task AddMovementAsync(Movement movement)
        {
            await _context.MovementItems.AddAsync(movement);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movement>> GetAllMovementsAsync()
        {
            var movementItems = await _context.MovementItems.ToListAsync();
            return movementItems;
        }

        public async Task DeleteMovementAsync(Movement movement)
        {
            await _context.MovementItems.Where(m => m.MovementID == movement.MovementID).ExecuteDeleteAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}