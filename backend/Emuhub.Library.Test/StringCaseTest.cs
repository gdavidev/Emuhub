using Emuhub.Library.Transformation;

namespace Emuhub.Library.Test;

public class StringCaseTest
{
    [Fact]
    public void ToKebabCase_WithSpaces_Success()
    {
        const string sample = "super metroid";
        
        var result = StringCase.ToKebabCase(sample);
        
        Assert.Equal("super-metroid", result);
    }
    
    [Fact]
    public void ToKebabCase_AlreadyKebabCase_Success()
    {
        const string sample = "super-metroid";
        
        var result = StringCase.ToKebabCase(sample);
        
        Assert.Equal("super-metroid", result);
    }
}