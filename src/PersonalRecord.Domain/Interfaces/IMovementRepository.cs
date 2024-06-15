﻿namespace PersonalRecord.Domain.Interfaces
{
    using PersonalRecord.Domain.Models.Entities;

    public interface IMovementRepository
    {
        Task AddMovementAsync(Movement movement);

        Task AddOrUpdateAllAsync(IEnumerable<Movement> movements);

        Task<IEnumerable<Movement>> GetAllMovementsAsync();

        Task DeleteMovementAsync(Movement movement);

        Task SaveAsync();
    }
}