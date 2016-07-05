using System;
using System.Collections.Generic;

namespace Sautom.Queries.ReadOptimizedDto
{
    public class AunthorizationCredentialsDto
    {
	    public Guid Id { get; set; }
	    public string UserName { get; set; }
	    public string UserDisplayName { get; set; }
	    public List<string> Roles { get; set; }
    }
}
