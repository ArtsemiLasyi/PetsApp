namespace ArtsemiLasyi.PetsApp.DataAccess.Repositories.Implementations;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions;
using Entities;
using Contexts;
using Microsoft.EntityFrameworkCore;

public class PetBreedRepository(
    PetsAppDbContext dbContext
) : IPetBreedRepository
{
    private readonly PetsAppDbContext petsAppDbContext = dbContext;

    public Task<List<PetBreed>> GetAsync(int pageNumber, int pageSize)
    {
        return petsAppDbContext.PetBreeds
            .Include(p => p.PetType)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<PetBreed?> GetByIdAsync(Guid id)
    {
        return petsAppDbContext.PetBreeds
            .Include(p => p.PetType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}