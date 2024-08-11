namespace ArtsemiLasyi.PetsApp.Responses;

public record PageResponse<T>(int PageNumber, int PageSize, List<T> Values);