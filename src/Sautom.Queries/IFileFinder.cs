using System;
using System.Collections.Generic;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.Queries
{
    public interface IFileFinder
    {
	    ICollection<GuidStringDto> ClientFileList(Guid clientId);
	    FileDownloadDto ClientFile(Guid fileId);
    }
}
