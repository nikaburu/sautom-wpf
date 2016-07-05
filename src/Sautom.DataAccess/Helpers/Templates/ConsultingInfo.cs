using System;
using System.Collections.Generic;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Helpers.Templates
{
    public class ConsultingInfo : IDocumentTemplate
    {
	    private const string TemplateName = "consultingGroupTemplate.docx";

	    private readonly string _path;

	    public ConsultingInfo(string templateFolderPath)
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

            if (!contract.ConsultingDate.HasValue || !contract.ConsultingActDate.HasValue || !client.PassportByDate.HasValue) return null;

            DocumentData docData = new DocumentData
            {
                                  TemplatePath = _path + TemplateName,
                                  Strings = new Dictionary<string, string>
                                  {
                                                    {"ContractNumber", contract.ConsultingNumber},
                                                    {"DateFromText", TemplateHelpers.DateToText(contract.ConsultingDate.Value)},
                                                    {"ActDateFromText", TemplateHelpers.DateToText(contract.ConsultingDate.Value)},
                                                    {"ActHoursText", TemplateHelpers.HoursToText(contract.ConsultingHours)},
                                                    {"ActSumText", TemplateHelpers.SumToText(contract.ConsultingSum)},
                                                    {"ActSumNdsText", TemplateHelpers.SumToText(contract.ConsultingSum * 0.2f)},

                                                    {"ClinetFullName", client.FullName},
                                                    {"ClinetShortName", TemplateHelpers.NameToShort(client.FullName)},
                                                    {"ClinetPassportNumber", client.PassportInfo},
                                                    {"ClinetAddress", client.Address},
                                                    {"ClinetPhone", client.PhoneFirst ?? client.PhoneSecond},
                                                    {"ClinetPassportWhen", client.PassportByDate.Value.ToShortDateString()},

                                                    {"CuratorFullName", manager.DisplayNameBy},
                                                    {"CuratorNumber", manager.Number},
                                                    {"CuratorDate", manager.AccreditationDate.ToShortDateString()},
                                                    {"CuratorPosition", manager.Position},
                                                    {"CuratorShortName", manager.DisplayName}
                                                }
                              };

            if (contract.Order.Proposal.IsGroupType)
            {
                docData.TemplatePath = _path + TemplateName;

                Dictionary<string, string> add = new Dictionary<string, string>
                {
                                  { "", "" }
                              };

                foreach (KeyValuePair<string, string> rec in add)
                {
                    docData.Strings.Add(rec.Key, rec.Value);
                }
            }

            return docData;
        }
    }
}