namespace ArtsemiLasyi.PetsApp.DataAccess.Repositories.Implementations;

using System;
using Core;
using Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Abstractions;

public class PetRepository(PetsAppDbContext dbContext) : IPetRepository
{
    private readonly PetsAppDbContext petsAppDbContext = dbContext;

    public async Task<DeleteOperationResult> DeleteByIdAsync(Guid id)
    {
        var pet = petsAppDbContext.Pets.FirstOrDefault(p => p.Id == id);
        if (pet is null)
        {
            return DeleteOperationResult.NotFound;
        }

        petsAppDbContext.Pets.Remove(pet);
        try
        {
            await petsAppDbContext.SaveChangesAsync();
        }
        catch
        {
            return DeleteOperationResult.CannotDelete;
        }

        return DeleteOperationResult.Successfull;
    }

    public Task<Pet?> GetByIdAsync(Guid id)
    {
        return petsAppDbContext.Pets
            .Include(p => p.PetBreed)
            .ThenInclude(p => p.PetType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<Pet>> GetAsync(int pageNumber, int pageSize)
    {
        return petsAppDbContext.Pets
            .Include(p => p.PetBreed)
            .ThenInclude(p => p.PetType)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task InsertAsync(Pet pet)
    {
        petsAppDbContext.Pets.Add(pet);
        return petsAppDbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Pet pet)
    {
        petsAppDbContext.Pets.Attach(pet);
        petsAppDbContext.Pets.Update(pet);
        return petsAppDbContext.SaveChangesAsync();
    }
}