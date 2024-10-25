namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;
    using System;

    public interface IMovementRecordRepository
    {
        Task AddMovementRecordAsync(MovementRecord movementRecord);

        Task<MovementRecord> GetMovementRecordByIdAsync(Guid movementRecordID);

        Task<IEnumerable<MovementRecord>> GetAllMovementRecordsAsync();

        Task UpdateAllEntriesAsync(IEnumerable<MovementRecord> movementRecords);

        Task DeleteMovementRecordAsync(MovementRecord movementRecord);
    }
}