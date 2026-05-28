using payment_service.Core.ContributorAggregate;

namespace payment_service.UseCases.Contributors.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateContributorCommand(ContributorName Name, string? PhoneNumber) : ICommand<Result<ContributorId>>;
