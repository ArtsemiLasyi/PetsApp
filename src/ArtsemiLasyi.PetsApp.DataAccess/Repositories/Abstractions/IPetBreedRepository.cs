namespace ArtsemiLasyi.PetsApp.DataAccess.Repositories.Abstractions;

using Entities;

public interface IPetBreedRepository
{
    Task<List<PetBreed>> GetAsync(int pageNumber, int pageSize);

    Task<PetBreed?> GetByIdAsync(Guid id);
}