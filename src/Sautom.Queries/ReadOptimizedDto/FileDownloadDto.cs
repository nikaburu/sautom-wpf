using System;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class FileDownloadDto
    {
	    public Guid Id { get; set; }

	    public string FileName { get; set; }
	    public string FileExtension { get; set; }
	    public byte[] FileData { get; set; }
    }
}
