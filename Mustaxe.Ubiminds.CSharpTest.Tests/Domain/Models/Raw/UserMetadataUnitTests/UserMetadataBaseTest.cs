using Bogus;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Domain.Models.Raw.UserMetadataUnitTests;

public class UserMetadataBaseTest
{
    protected readonly UserMetadata _userMetadata = new();
    protected readonly Faker _faker = new();
}
