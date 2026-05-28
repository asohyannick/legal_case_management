namespace payment_service.UseCases;

public record PagedResult<T>(
  IReadOnlyList<T> Items,
  int Page,
  int PerPage,
  int TotalCount,
  int TotalPages);
