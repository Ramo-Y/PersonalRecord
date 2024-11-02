﻿namespace PersonalRecord.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using PersonalRecord.Domain.Interfaces;
    using PersonalRecord.Domain.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly PersonalRecordContext _context;

        public WorkoutRepository(PersonalRecordContext context)
        {
            _context = context;
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            await _context.WorkoutItems.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkoutAsync(Workout workout)
        {
            await _context.WorkoutItems.Where(w => w.WorkoutID == workout.WorkoutID).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            var workoutItems = await _context.WorkoutItems
                .Include(w => w.WokWorkoutToExerciseItems)
                .ThenInclude(w => w.Exercise)
                .OrderBy(w => w.WokName)
                .ToListAsync();
            return workoutItems;
        }

        public async Task<Workout> GetWorkoutByIdAsync(Guid workoutID)
        {
            var workout = await _context.WorkoutItems.FindAsync(workoutID);
            return workout;
        }

        public bool IsWorkoutInUse(Workout workout)
        {
            var isInUse = _context.WorkoutRecordItems.Any(wr => wr.Workout.Equals(workout));
            return isInUse;
        }
    }
}