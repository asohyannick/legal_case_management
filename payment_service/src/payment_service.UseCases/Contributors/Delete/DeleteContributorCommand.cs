using payment_service.Core.ContributorAggregate;

namespace payment_service.UseCases.Contributors.Delete;

public record DeleteContributorCommand(ContributorId ContributorId) : ICommand<Result>;
