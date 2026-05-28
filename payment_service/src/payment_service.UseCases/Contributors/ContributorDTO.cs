using payment_service.Core.ContributorAggregate;

namespace payment_service.UseCases.Contributors;
public record ContributorDto(ContributorId Id, ContributorName Name, PhoneNumber PhoneNumber);
