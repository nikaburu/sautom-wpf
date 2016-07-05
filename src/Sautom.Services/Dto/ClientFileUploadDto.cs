using System;

namespace Sautom.Services.Dto
{
    public sealed class ClientFileUploadDto
    {
	    public string FileName { get; set; }
	    public string FileExtension { get; set; }
	    public byte[] FileData { get; set; }

	    public Guid ClientId { get; set; }
    }
}
