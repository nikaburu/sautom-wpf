using System.Collections.Generic;

namespace Sautom.Services
{
    public interface ICommandState
    {
	    Dictionary<string, object> State { get; }
	    bool IsValid { get; }
    }

    public class DefaultCommandState : ICommandState
    {
	    public Dictionary<string, object> State { get; set; }
	    public bool IsValid { get; set; }
    }
}
