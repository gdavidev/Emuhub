using Microsoft.AspNetCore.Http.Internal;

namespace Emuhub.TestingUtilities
{
	public class FileMock
	{
		public static FormFile Create(string filename)
		{
			return new FormFile(new MemoryStream([]), 0, 0, "", filename);
		}

		public static FormFile Create(string filename, Stream content)
		{
			return new FormFile(content, 0, content.Length, "", filename);
		}
	}
}
