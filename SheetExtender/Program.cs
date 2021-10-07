using System;
using Newtonsoft.Json.Linq;
using Qlik.Engine;
using Qlik.Sense.Client;

namespace SheetExtender
{
	class Program
	{
		static void Main(string[] args)
        {
            var url = "<url>";
            var appId = "<appId>";
            var sheetId = "<sheetId>";

            var location = Location.FromUri(url);
            location.AsNtlmUserViaProxy(certificateValidation: false);

            using (var app = location.App(appId))
            {
                var sheet = app.GetObject<Sheet>(sheetId);
                using (sheet.SuspendedLayout)
                {
                    var layoutOptions = new JObject();
                    sheet.Properties.Rows = 18;
                    layoutOptions["extendable"] = true;
                    sheet.Properties.Set("layoutOptions", new AbstractStructure(layoutOptions));
                    sheet.Properties.Set("height", 150);
                }
            }
        }
	}
}
