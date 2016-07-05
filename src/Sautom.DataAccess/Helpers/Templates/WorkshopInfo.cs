using System;
using System.Collections.Generic;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Helpers.Templates
{
    public class WorkshopInfo : IDocumentTemplate
    {
	    private const string TemplateName = "workshopTemplate.docx";

	    private readonly string _path;

	    public WorkshopInfo(string templateFolderPath)
        {
            _path = templateFolderPath;
        }

	    #region Implementation of IDocumentTemplate

	    public DocumentData GetDocumentData(DatabaseContext context, Guid contractId)
        {
            return GetDocumentDataInternal(context, contractId);
        }

	    #endregion

	    private DocumentData GetDocumentDataInternal(DatabaseContext context, Guid contractId)
        {
            Contract contract = context.Contracts.Find(contractId);
            Client client = context.Clients.Find(contract.Order.Client.Id);
            Manager manager = contract.Order.ResponsibleManager;

            if (contract.WorkshopDate != null && contract.WorkshopActDate != null)
                return new DocumentData
                {
                               TemplatePath = _path + TemplateName,
                               Strings = new Dictionary<string, string>
                               {
                                                     {"ContractNumber", contract.WorkshopNumber},
                                                     {"DateFromText", TemplateHelpers.DateToText(contract.WorkshopDate.Value)},
                                                     {"ActDateFromText", TemplateHelpers.DateToText(contract.WorkshopActDate.Value)},
                                                     {"ActHoursText", TemplateHelpers.HoursToText(contract.WorkshopHours)},
                                                     {"ActSumText", TemplateHelpers.SumToText(contract.WorkshopSum)},

                                                     {"ClinetFullName", client.FullName},
                                                     {"ClinetShortName", TemplateHelpers.NameToShort(client.FullName)},
                                                     {"ClinetPassportNumber", client.PassportInfo},
                                                     {"ClinetAddress", client.Address},
                                                     {"ClinetPhone", client.PhoneFirst ?? client.PhoneSecond},

                                                     {"CuratorFullName", manager.DisplayNameBy},
                                                     {"CuratorNumber", manager.Number},
                                                     {"CuratorDate", manager.AccreditationDate.ToShortDateString()},
                                                     {"CuratorPosition", manager.Position},
                                                     {"CuratorShortName", manager.DisplayName}
                                                 }
                           };

            return null;
        }
    }
}