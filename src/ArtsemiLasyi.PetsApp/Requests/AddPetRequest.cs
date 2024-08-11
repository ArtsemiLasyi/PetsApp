namespace ArtsemiLasyi.PetsApp.Requests;

public record AddPetRequest(
    string Name,
    DateTime BirthDate,
    float Weight,
    Guid PetBreedId
);