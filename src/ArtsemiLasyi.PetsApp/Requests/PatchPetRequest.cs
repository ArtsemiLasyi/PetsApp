namespace ArtsemiLasyi.PetsApp.Requests;

public record PatchPetRequest(
    string? Name,
    DateTime? BirthDate,
    float? Weight,
    Guid? PetBreedId
);