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

        public async Task AddOrUpdateAllAsync(IEnumerable<Movement> movements)
        {
            foreach (var movement in movements)
            {
                var find = await _context.MovementItems.FindAsync(movement.MovementID);
                if (find == null)
                {
                    await _context.MovementItems.AddAsync(movement);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movement>> GetAllMovementsAsync()
        {
            var movementItems = await _context.MovementItems.OrderBy(m => m.MovName).ToListAsync();
            return movementItems;
        }

        public bool IsMovementInUse(Movement movement)
        {
            var isInUse = _context.MovementRecordItems.Any(m => m.Movement.Equals(movement));
            return isInUse;
        }

        public async Task DeleteMovementAsync(Movement movement)
        {
            await _context.MovementItems.Where(m => m.MovementID == movement.MovementID).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}