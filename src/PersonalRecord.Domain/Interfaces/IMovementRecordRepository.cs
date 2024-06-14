namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IMovementRecordRepository
    {
        Task AddMovementRecordAsync(MovementRecord movementRecord);

        Task<IEnumerable<MovementRecord>> GetAllMovementRecordsAsync();

        Task DeleteMovementRecordAsync(MovementRecord movementRecord);

        Task SaveAsync();
    }
}