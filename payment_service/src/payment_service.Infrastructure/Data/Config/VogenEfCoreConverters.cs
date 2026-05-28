using payment_service.Core.ContributorAggregate;
using Vogen;

namespace payment_service.Infrastructure.Data.Config;

[EfCoreConverter<ContributorId>]
[EfCoreConverter<ContributorName>]
internal partial class VogenEfCoreConverters;
