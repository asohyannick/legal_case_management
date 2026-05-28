using auth_service.Core.ContributorAggregate;

namespace auth_service.UseCases.Contributors.Delete;

public record DeleteContributorCommand(ContributorId ContributorId) : ICommand<Result>;
