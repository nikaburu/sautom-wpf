using System;

namespace Sautom.Domain.Entities
{
    public class ClientFile : IEntity
    {
	    public string FileName { get; set; }
	    public string FileExtension { get; set; }
	    public byte[] FileData { get; set; }

	    public virtual Client Client { get; set; }
	    public Guid Id { get; set; }
    }
}
