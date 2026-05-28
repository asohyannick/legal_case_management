using auth_service.Core.ContributorAggregate;

namespace auth_service.UseCases.Contributors.Get;

public record GetContributorQuery(ContributorId ContributorId) : IQuery<Result<ContributorDto>>;
