using System;

namespace Sautom.Queries.ReadOptimizedDto
{
    public sealed class ManagerCommentItemDto
    {
	    public Guid Id { get; set; }

	    public string Manager { get; set; }
	    public DateTime Date { get; set; }
	    public string Comment { get; set; }
    }
}
