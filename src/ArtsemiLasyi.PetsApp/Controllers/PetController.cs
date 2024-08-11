namespace ArtsemiLasyi.PetsApp.Controllers;

using DataAccess.Repositories.Abstractions;
using ArtsemiLasyi.PetsApp.Responses;
using Microsoft.AspNetCore.Mvc;
using Requests;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Core;
using System.Net.Mime;

[ApiController]
[Route("/pets")]
public class PetController(
    IPetRepository petRepository,
    IPetBreedRepository petBreedRepository,
    IMapper mapper
) : ControllerBase
{
    private readonly IPetRepository petRepository = petRepository;
    private readonly IPetBreedRepository petBreedRepository = petBreedRepository;
    private readonly IMapper mapper = mapper;

    [HttpGet("{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPet(
        [FromRoute] Guid id
    )
    {
        var pet = await petRepository.GetByIdAsync(id);
        if (pet is null)
        {
            return NotFound();
        }

        var result = mapper.Map<PetResponse>(pet);
        return Ok(result);
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<PageResponse<PetResponse>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PageResponse<PetResponse>>> GetPets(
        [FromQuery] PageRequest request
    )
    {
        var pets = await petRepository.GetAsync(
            request.PageNumber,
            request.PageSize
        );

        var values = mapper.Map<List<PetResponse>>(pets);
        return Ok(
            new PageResponse<PetResponse>(
                request.PageNumber,
                request.PageSize,
                values
            )
        );
    }

    [HttpPost]
    public async Task<ActionResult> CreatePet(
        [FromBody] AddPetRequest request
    )
    {
        var petBreed = await petBreedRepository.GetByIdAsync(
            request.PetBreedId
        );

        if (petBreed is null)
        {
            return BadRequest(
                $"There is no pet breed with id = {request.PetBreedId}"
            );
        }

        await petRepository.InsertAsync(
            new Pet()
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
                WeightInGrams = request.Weight,
                PetBreedId = request.PetBreedId
            }
        );

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchPet(
        Guid id,
        [FromBody] PatchPetRequest request
    )
    {
        var pet = await petRepository.GetByIdAsync(id);
        if (pet is null)
        {
            return NotFound();
        }

        if (request.PetBreedId.HasValue)
        {
            var petBreed = await petBreedRepository.GetByIdAsync(
                request.PetBreedId.Value
            );

            if (petBreed is null)
            {
                return BadRequest(
                    $"There is no pet breed with id = {request.PetBreedId.Value}"
                );
            }
        }

        pet.Name = request.Name ?? pet.Name;
        pet.BirthDate = request.BirthDate ?? pet.BirthDate;
        pet.WeightInGrams = request.Weight ?? pet.WeightInGrams;
        pet.PetBreedId = request.PetBreedId ?? pet.PetBreedId;

        await petRepository.UpdateAsync(pet);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePet(Guid id)
    {
        var result = await petRepository.DeleteByIdAsync(id);

        return result switch
        {
            DeleteOperationResult.NotFound => NotFound(),
            DeleteOperationResult.CannotDelete => BadRequest(
                "Operation cannot be executed"
            ),
            DeleteOperationResult.Successfull => Ok(),
            _ => throw new NotImplementedException()
        };
    }
}
