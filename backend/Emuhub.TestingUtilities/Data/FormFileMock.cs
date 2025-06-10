using Microsoft.AspNetCore.Http;
using Moq;

namespace Emuhub.TestingUtilities.Data;

public class FormFileMock : Mock<IFormFile>
{
    public FormFileMock(string fileName)
    {
        MockName(fileName);
    }

    public FormFileMock(string fileName, long length)
    {
        MockName(fileName);
        MockLength(length);
    }

    public void MockName(string name)
    {
        Setup(f => f.Name).Returns(name);
    }

    public void MockLength(long length)
    {
        Setup(f => f.Length).Returns(length);
    }
}