using Bogus;
using Mustaxe.Ubiminds.CSharpTest.Domain.Models.Raw;

namespace Mustaxe.Ubiminds.CSharpTest.Tests.Domain.Models.Raw.CompanyMetadataUnitTests;

public class CompanyMetadataBaseTest
{
    protected readonly CompanyMetadata _companyMetadata = new();
    protected readonly Faker _faker = new();
}
