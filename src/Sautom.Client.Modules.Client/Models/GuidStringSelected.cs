using System;

namespace Sautom.Client.Modules.Client.Models
{
    public sealed class GuidStringSelected
    {
	    public Guid Id { get; set; }
	    public string Value { get; set; }
	    public bool IsSelected { get; set; }
	    public string SelectionGroup { get; set; }
    }
}
