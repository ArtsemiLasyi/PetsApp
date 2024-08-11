namespace ArtsemiLasyi.PetsApp.DataAccess.Repositories.Abstractions;

using Core;
using Entities;

public interface IPetRepository
{
    Task<List<Pet>> GetAsync(int pageNumber, int pageSize);

    Task<Pet?> GetByIdAsync(Guid id);

    Task InsertAsync(Pet pet);

    Task UpdateAsync(Pet pet);

    Task<DeleteOperationResult> DeleteByIdAsync(Guid id);
}