using auth_service.Core.ContributorAggregate;

namespace auth_service.UseCases.Contributors;
public record ContributorDto(ContributorId Id, ContributorName Name, PhoneNumber PhoneNumber);
