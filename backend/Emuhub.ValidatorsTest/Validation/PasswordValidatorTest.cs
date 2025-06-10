using Emuhub.Application.Validation;

namespace Emuhub.ApplicationTest.Validation;

public class PasswordValidatorTest
{
    //[Fact]
    //public void IsPasswordValid_ReturnsTrue_GoodEnoughPassword()
    //{
    //    var sample = "Abcde123";

    //    var result = new PasswordValidator().Validate(sample);

    //    Assert.True(result.IsValid);
    //}

    //[Fact]
    //public void IsPasswordValid_ReturnsFalse_NotEnoughtCharacters()
    //{
    //    var sample = "Abc123";

    //    var result = new PasswordValidator().Validate(sample);

    //    Assert.False(result.IsValid);
    //}

    //[Theory]
    //[InlineData("abcde123")] // Missing uppercase
    //[InlineData("ABCDE123")] // Missing lowercase
    //[InlineData("ABCDEabc")] // Missing number
    //public void IsPasswordValid_ReturnsFalse_MissingCharacterVariation(string sample)
    //{
    //    var result = new PasswordValidator().Validate(sample);

    //    Assert.False(result.IsValid);
    //}

    //[Theory]
    //[InlineData("")]
    //public async Task IsPasswordValid_ReturnsFalse_PasswordNullOrEmpty(string sample)
    //{
    //    var result = await new PasswordValidator().ValidateAsync(sample);

    //    Assert.False(result.IsValid);
    //}
}