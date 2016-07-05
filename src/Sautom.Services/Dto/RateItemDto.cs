using System;

namespace Sautom.Services.Dto
{
    public sealed class RateItemDto
    {
	    public Guid Id { get; set; }

	    public DateTime Date { get; set; }
	    public float RateValue { get; set; }
    }
}
