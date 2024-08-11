namespace ArtsemiLasyi.PetsApp.Responses;

public class PetResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public float WeightInGrams { get; set; }
    public int AgeInMonths { get; set; }
    public string PetTypeName { get; set; } = null!;
    public string PetBreedName { get; set; } = null!;
}