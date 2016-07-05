using System;

namespace Sautom.DataAccess.Helpers.Templates
{
    public interface IDocumentTemplate
    {
	    DocumentData GetDocumentData(DatabaseContext context, Guid clientId);
    }
}
