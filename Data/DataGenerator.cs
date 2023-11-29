using Bogus;

namespace BogusData.Data;

public class DataGenerator
{
    Faker<PersonModel> personModelFake;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(123);

        personModelFake = new Faker<PersonModel>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 10000))
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.State, f => f.Address.State())
            .RuleFor(u => u.ZipCode, f => f.Address.ZipCode())
            .RuleFor(u => u.Rating, f => f.PickRandom<CreditRating>());
    }

    public PersonModel GeneratePerson()
    {
        return personModelFake.Generate();
    }

    public IEnumerable<PersonModel> GeneratePeople()
    {
        return personModelFake.GenerateForever();
    }
}
