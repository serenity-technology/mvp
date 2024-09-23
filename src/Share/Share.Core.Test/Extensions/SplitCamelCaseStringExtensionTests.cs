namespace Share.Core.Test;

public class SplitCamelCaseStringExtensionTests
{
    /// <summary>
    /// Test for Null or Empty
    /// </summary>
    [Test]
    public async Task IsNullOrEmpty()
    {
        var input = string.Empty;

        var output = input.ToSplitCamelCase();
        await Assert.That(output).IsEqualTo(string.Empty);
    }

    /// <summary>
    /// Test for lower case
    /// </summary>
    [Test]
    public async Task LowerCase()
    {
        var input = "lower";

        var output = input.ToSplitCamelCase();
        await Assert.That(output).IsEqualTo("Lower");
    }

    /// <summary>
    /// Test for lower case
    /// </summary>
    [Test]
    public async Task UpperCase()
    {
        var input = "UPPER";

        var output = input.ToSplitCamelCase();
        await Assert.That(output).IsEqualTo("UPPER");
    }

    /// <summary>
    /// Test for one word
    /// </summary>
    [Test]
    public async Task OneWord()
    {
        var input = "One";

        var output = input.ToSplitCamelCase();
        await Assert.That(output).IsEqualTo("One");
    }

    /// <summary>
    /// Test for one word
    /// </summary>
    [Test]
    public async Task MultiWord()
    {
        var input = "MultiWord";

        var output = input.ToSplitCamelCase();
        await Assert.That(output).IsEqualTo("Multi Word");
    }
}