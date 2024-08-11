namespace ArtsemiLasyi.PetsApp.DataAccess.Contexts;

using ArtsemiLasyi.PetsApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class PetsAppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pet> Pets { get; set; }

    public DbSet<PetType> PetTypes { get; set; }

    public DbSet<PetBreed> PetBreeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pet>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Pet>()
            .HasOne(p => p.PetBreed)
            .WithMany()
            .HasForeignKey(p => p.PetBreedId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PetBreed>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<PetBreed>()
            .HasOne(p => p.PetType)
            .WithMany()
            .HasForeignKey(p => p.PetTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PetType>()
            .HasKey(p => p.Id);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        Guid CatGuid = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
        Guid DogGuid = Guid.Parse("0f9fad5b-d9cb-469f-a165-70867728950e");
        Guid ParrotGuid = Guid.Parse("0fafad5b-d9cb-469f-a165-70867728950e");

        Guid MacawGuid = Guid.Parse("0fbfad5b-d9cb-469f-a165-70867728950e");
        Guid CockatooGuid = Guid.Parse("0fcfad5b-d9cb-469f-a165-70867728950e");
        Guid CaiqueGuid = Guid.Parse("0fdfad5b-d9cb-469f-a165-70867728950e");

        Guid AbyssinianGuid = Guid.Parse("0fefad5b-d9cb-469f-a165-70867728950e");
        Guid BengalGuid = Guid.Parse("0fffad5b-d9cb-469f-a165-70867728950e");
        Guid BritishShorthairGuid = Guid.Parse(
            "0faaad5b-d9cb-469f-a165-70867728950e"
        );

        Guid AlaskanMalamuteGuid = Guid.Parse(
            "0fabad5b-d9cb-469f-a165-70867728950e"
        );
        Guid KomondorGuid = Guid.Parse("0facad5b-d9cb-469f-a165-70867728950e");
        Guid DreverGuid = Guid.Parse("0fadad5b-d9cb-469f-a165-70867728950e");

        modelBuilder.Entity<PetType>()
            .HasData(
                [
                    new PetType()
                    {
                        Id = DogGuid,
                        Name = "Dog"
                    },
                    new PetType()
                    {
                        Id = CatGuid,
                        Name = "Cat"
                    },
                    new PetType()
                    {
                        Id = ParrotGuid,
                        Name = "Parrot"
                    }
                ]
            );

        modelBuilder.Entity<PetBreed>()
            .HasData(
                [
                    new PetBreed()
                    {
                        Id = MacawGuid,
                        Name = "Macaw",
                        PetTypeId = ParrotGuid
                    },
                    new PetBreed()
                    {
                        Id = CockatooGuid,
                        Name = "Cockatoo",
                        PetTypeId = ParrotGuid
                    },
                    new PetBreed()
                    {
                        Id = CaiqueGuid,
                        Name = "Caique",
                        PetTypeId = ParrotGuid
                    },
                    new PetBreed()
                    {
                        Id = AbyssinianGuid,
                        Name = "Abyssinian",
                        PetTypeId = CatGuid
                    },
                    new PetBreed()
                    {
                        Id = BengalGuid,
                        Name = "Bengal",
                        PetTypeId = CatGuid
                    },
                    new PetBreed()
                    {
                        Id = BritishShorthairGuid,
                        Name = "British Shrthair",
                        PetTypeId = CatGuid
                    },new PetBreed()
                    {
                        Id = AlaskanMalamuteGuid,
                        Name = "Alaskan Malamute",
                        PetTypeId = DogGuid
                    },
                    new PetBreed()
                    {
                        Id = KomondorGuid,
                        Name = "Komondor",
                        PetTypeId = DogGuid
                    },
                    new PetBreed()
                    {
                        Id = DreverGuid,
                        Name = "Drever",
                        PetTypeId = DogGuid
                    }
                ]
            );
    }
}
