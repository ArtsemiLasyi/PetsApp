namespace ArtsemiLasyi.PetsApp.DataAccess.Entities;

public class Pet
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public float WeightInGrams { get; set; }

    public DateTime BirthDate { get; set; }

    public Guid PetBreedId { get; set; }

    public PetBreed PetBreed { get; set; } = null!;
}
