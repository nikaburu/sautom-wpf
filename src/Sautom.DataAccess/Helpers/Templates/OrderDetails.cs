using System;
using System.Collections.Generic;
using System.Linq;
using Sautom.Domain.Entities;

namespace Sautom.DataAccess.Helpers.Templates
{
    public class OrderDetails : IDocumentTemplate
    {
	    private const string TemplateName = "clientTemplate.docx";

	    private readonly string _path;

	    public OrderDetails(string templateFolderPath)
        {
            _path = templateFolderPath;
        }

	    #region Implementation of IDocumentTemplate

	    public DocumentData GetDocumentData(DatabaseContext context, Guid orderId)
        {
            return GetDocumentDataInternal(context, orderId);
        }

	    #endregion

	    private DocumentData GetDocumentDataInternal(DatabaseContext context, Guid orderId)
        {
            Order order = context.Orders.Find(orderId);
            Client client = order.Client;

            List<string> docs = order.Proposal.City.Country.EmbassyDocuments
                .Where(rec => !order.EmbassyDocuments.Contains(rec)).Select(rec => rec.DocumentName).ToList();

            return new DocumentData
            {
                               TemplatePath = _path + TemplateName,
                               Strings = new Dictionary<string, string>
                               {
                                                     {"ClientFullName", client.FullName},
                                                     {"ClientAddress", client.Address},
                                                     {"ClientPhone", client.PhoneFirst ?? client.PhoneSecond},

                                                     {"OrderSchool", order.Proposal.SchoolName},
                                                     {"OrderCource", order.Proposal.CourseName},
                                                     {"OrderStartDate", TemplateHelpers.DateToText(order.StartDate)},
                                                     {"OrderEndDate", TemplateHelpers.DateToText(order.EndDate)},
                                                     {"OrderIntensivity", order.Intensity.IntensityName},
                                                     {"OrderHouseType", order.HouseType.HousingName},
                                                     {"OrderEmbassyDate", order.EmbassyDate.HasValue ? TemplateHelpers.DateToText(order.EmbassyDate.Value) : "-"},
                                                     {"OrderVisaDate", order.VisaDate.HasValue ? TemplateHelpers.DateToText(order.VisaDate.Value) : "-"},
                                                     {"OrderDocuments", docs.Count > 0 ? docs.Aggregate((sum, item) => sum + ", " + item) : "-"}
                                                 }
                           };
        }
    }
}