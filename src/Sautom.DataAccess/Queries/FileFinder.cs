using System;
using System.Collections.Generic;
using System.Linq;
using Sautom.Queries;
using Sautom.Queries.ReadOptimizedDto;

namespace Sautom.DataAccess.Queries
{
    public sealed class FileFinder : FinderBase, IFileFinder
    {
	    #region Constructors

	    #endregion

	    #region Implementation of IFileFinder

	    public ICollection<GuidStringDto> ClientFileList(Guid clientId)
        {
            return DatabaseContext.Files.Where(rec => rec.Client.Id == clientId).Select(rec => new GuidStringDto {Id = rec.Id, Element = rec.FileName + rec.FileExtension}).ToList();
        }

	    public FileDownloadDto ClientFile(Guid fileId)
        {
            return DatabaseContext.Files.Select(rec => new FileDownloadDto
                                                   {
                                                       FileData = rec.FileData,
                                                       Id = rec.Id,
                                                       FileExtension = rec.FileExtension,
                                                       FileName = rec.FileName
                                                   }).FirstOrDefault(rec => rec.Id == fileId);
        }

	    #endregion
    }
}
