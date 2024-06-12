namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IMovementRepository
    {
        Task AddMovement(Movement movement);

        Task<IEnumerable<Movement>> GetMovements();
    }
}