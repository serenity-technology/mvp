namespace Share.Core.Test;

public enum MockEnum
{
    /// <summary>
    /// No attributes
    /// </summary>
    Plain,

    /// <summary>
    /// Description only attribute
    /// </summary>
    [EnumDescription("description")]
    DescriptionOnly,

    /// <summary>
    /// Description and Code attributes
    /// </summary>
    [EnumDescription("description")]
    [EnumCode("code")]
    DescriptionCode,

    /// <summary>
    /// Description and Guid attributes
    /// </summary>
    [EnumDescription("description")]
    [EnumGuid("76a442d0-ad8a-4012-8732-c21f2f42b707")]
    DescriptionGuid,

    /// <summary>
    /// Code only attribute
    /// </summary>
    [EnumCode("code")]
    CodeOnly,

    /// <summary>
    /// Code and Guid attributes
    /// </summary>
    [EnumCode("code")]
    [EnumGuid("76a442d0-ad8a-4012-8732-c21f2f42b707")]
    CodeGuid,

    /// <summary>
    /// Guid only attribute
    /// </summary>
    [EnumGuid("76a442d0-ad8a-4012-8732-c21f2f42b707")]
    GuidOnly,

    /// <summary>
    /// Description, Code and Guid attributes
    /// </summary>
    [EnumDescription("description")]
    [EnumCode("code")]
    [EnumGuid("76a442d0-ad8a-4012-8732-c21f2f42b707")]
    DescriptionCodeGuid,

    /// <summary>
    /// Multi Word Enum with description
    /// </summary>
    [EnumDescription("Multi Word With Description")]
    [EnumGuid("76a442d0-ad8a-4012-8732-c21f2f42b701")]
    MultiWordWithDescription,

    /// <summary>
    /// Multi Word
    /// </summary>
    MultiWord
}