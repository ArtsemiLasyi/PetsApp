namespace ArtsemiLasyi.PetsApp.DataAccess.Entities;

public class PetBreed
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid PetTypeId { get; set; }

    public PetType PetType { get; set; } = null!;
}