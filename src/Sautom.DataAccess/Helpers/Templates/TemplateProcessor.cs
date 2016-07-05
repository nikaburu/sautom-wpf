using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Novacode;

namespace Sautom.DataAccess.Helpers.Templates
{
    public static class TemplateProcessor
    {
	    private static IDocumentTemplate GetDocFormatData(string type)
        {
            return Templates.ContainsKey(type) ? Templates[type] : null;
        }

	    #region Fields

	    private static readonly object Mutex = new object();
	    private static readonly Lazy<Dictionary<string, IDocumentTemplate>> TemplatesLazy = new Lazy<Dictionary<string, IDocumentTemplate>>();
	    private static Dictionary<string, IDocumentTemplate> Templates => TemplatesLazy.Value;

	    #endregion

	    #region Public members

	    public static byte[] Process(DatabaseContext context, Guid entityId, string type)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU");

            lock (Mutex)
            {
                MemoryStream stream = new MemoryStream();

                IDocumentTemplate template = GetDocFormatData(type);
                if (template == null) return new byte[0];

                DocumentData data = template.GetDocumentData(context, entityId);
                if (data == null) return new byte[0];

                using (DocX document = DocX.Load(data.TemplatePath))
                {
                    foreach (KeyValuePair<string, string> str in data.Strings)
                    {
                        document.ReplaceText($"<#{str.Key}#>", str.Value);
                    }

                    document.SaveAs(stream);
                }

                return stream.GetBuffer();
            }
        }

	    public static void Register(string templateKey, IDocumentTemplate template)
        {
            Templates.Add(templateKey, template);
        }

	    #endregion
    }
}
