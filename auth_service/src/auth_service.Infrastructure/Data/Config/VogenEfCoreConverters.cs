using auth_service.Core.ContributorAggregate;
using Vogen;

namespace auth_service.Infrastructure.Data.Config;

[EfCoreConverter<ContributorId>]
[EfCoreConverter<ContributorName>]
internal partial class VogenEfCoreConverters;
