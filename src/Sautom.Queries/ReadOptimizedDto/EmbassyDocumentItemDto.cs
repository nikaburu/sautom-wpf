using System;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class EmbassyDocumentItemDto
    {
	    public Guid Id { get; set; }

	    public string DocumentName { get; set; }
	    public bool IsArchival { get; set; }
    }
}
