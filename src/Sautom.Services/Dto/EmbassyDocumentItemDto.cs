using System;

namespace Sautom.Services.Dto
{
    public sealed class EmbassyDocumentItemDto
    {
	    public Guid Id { get; set; }

	    public string DocumentName { get; set; }

	    public bool IsArchival { get; set; }
    }
}
