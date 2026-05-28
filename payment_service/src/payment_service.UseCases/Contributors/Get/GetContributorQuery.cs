using payment_service.Core.ContributorAggregate;

namespace payment_service.UseCases.Contributors.Get;

public record GetContributorQuery(ContributorId ContributorId) : IQuery<Result<ContributorDto>>;
