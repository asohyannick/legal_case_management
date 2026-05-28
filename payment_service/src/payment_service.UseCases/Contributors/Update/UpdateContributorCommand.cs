using payment_service.Core.ContributorAggregate;

namespace payment_service.UseCases.Contributors.Update;

public record UpdateContributorCommand(ContributorId ContributorId, ContributorName NewName) : ICommand<Result<ContributorDto>>;
