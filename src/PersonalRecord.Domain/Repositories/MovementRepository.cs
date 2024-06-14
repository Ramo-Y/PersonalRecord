namespace PersonalRecord.Domain.Repositories
{
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;

    public class MovementRepository : IMovementRepository
    {
        public async Task AddMovement(Movement movement)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movement>> GetAllMovements()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMovement(Movement movement)
        {
            throw new NotImplementedException();
        }
    }
}