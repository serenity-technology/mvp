namespace Share.Core.Test;

public class EnumerationTests
{    
    [Test]
    public async Task Plain()
    {
        var enumValue = MockEnum.Plain;

        await Assert.That(enumValue.Description()).IsEqualTo("Plain");
        await Assert.That(enumValue.Code()).IsEqualTo("");
        await Assert.That(enumValue.Guid()).IsEqualTo(Guid.Empty);
    }
        
    [Test]
    public async Task DescriptionOnly()
    {
        var enumValue = MockEnum.DescriptionOnly;

        await Assert.That(enumValue.Description()).IsEqualTo("description");
        await Assert.That(enumValue.Code()).IsEqualTo("");
        await Assert.That(enumValue.Guid()).IsEqualTo(Guid.Empty);
    }

    [Test]
    public async Task DescriptionCode()
    {
        var enumValue = MockEnum.DescriptionCode;

        await Assert.That(enumValue.Description()).IsEqualTo("description");
        await Assert.That(enumValue.Code()).IsEqualTo("code");
        await Assert.That(enumValue.Guid()).IsEqualTo(Guid.Empty);
    }

    [Test]
    public async Task DescriptionGuid()
    {
        var guid = new Guid("76a442d0-ad8a-4012-8732-c21f2f42b707");

        var enumValue = MockEnum.DescriptionGuid;

        await Assert.That(enumValue.Description()).IsEqualTo("description");
        await Assert.That(enumValue.Code()).IsEqualTo("");
        await Assert.That(enumValue.Guid()).IsEqualTo(guid);
    }

    [Test]
    public async Task CodeOnly()
    {
        var enumValue = MockEnum.CodeOnly;

        await Assert.That(enumValue.Description()).IsEqualTo("Code Only");
        await Assert.That(enumValue.Code()).IsEqualTo("code");
        await Assert.That(enumValue.Guid()).IsEqualTo(Guid.Empty);
    }

    [Test]
    public async Task CodeGuid()
    {
        var guid = new Guid("76a442d0-ad8a-4012-8732-c21f2f42b707");

        var enumValue = MockEnum.CodeGuid;

        await Assert.That(enumValue.Description()).IsEqualTo("Code Guid");
        await Assert.That(enumValue.Code()).IsEqualTo("code");
        await Assert.That(enumValue.Guid()).IsEqualTo(guid);
    }

    [Test]
    public async Task GuidOnly()
    {
        var guid = new Guid("76a442d0-ad8a-4012-8732-c21f2f42b707");

        var enumValue = MockEnum.GuidOnly;

        await Assert.That(enumValue.Description()).IsEqualTo("Guid Only");
        await Assert.That(enumValue.Code()).IsEqualTo("");
        await Assert.That(enumValue.Guid()).IsEqualTo(guid);
    }

    [Test]
    public async Task DescriptionCodeGuid()
    {
        var guid = new Guid("76a442d0-ad8a-4012-8732-c21f2f42b707");

        var enumValue = MockEnum.DescriptionCodeGuid;

        await Assert.That(enumValue.Description()).IsEqualTo("description");
        await Assert.That(enumValue.Code()).IsEqualTo("code");
        await Assert.That(enumValue.Guid()).IsEqualTo(guid);
    }

    [Test]
    public async Task ToList()
    {
        var list = Enums.ToList<MockEnum>();
        await Assert.That(list.Count).IsEqualTo(10);
    }

    [Test]
    public async Task ParseFromCode()
    {
        var enumSingle = Enums.ParseFromCode<MockEnumCode>("single");
        await Assert.That(MockEnumCode.Code1).IsEqualTo(enumSingle);
    }

    [Test]
    public async Task ParseFromGuid()
    {
        var guid = new Guid("76a442d0-ad8a-4012-8732-c21f2f42b701");
        var result = Enums.ParseFromGuid<MockEnum>(guid);

        await Assert.That(MockEnum.MultiWordWithDescription).IsEqualTo(result);
    }

    [Test]
    public async Task ParseFromDescription()
    {
        var result1 = Enums.ParseFromDescription<MockEnum>("Multi Word With Description");
        await Assert.That(MockEnum.MultiWordWithDescription).IsEqualTo(result1);

        var result2 = Enums.ParseFromDescription<MockEnum>("Multi Word");
        await Assert.That(MockEnum.MultiWord).IsEqualTo(result2);
    }
}