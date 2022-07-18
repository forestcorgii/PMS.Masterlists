using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Employees.ServiceLayer.HRMS.Adapter
{
    public class HRMSAdapterFactory
    {
        public static HRMSAdapter CreateAdapter(IConfigurationRoot config)
        {
            var section = config.GetRequiredSection("HRMSAPI");

            Dictionary<string, string> Urls = new();
            Urls.Add("MANILA", section.GetValue<string>("Url"));
            Urls.Add("LEYTE", section.GetValue<string>("Url_Leyte"));

            Dictionary<string, string> BodyArgs = new();
            BodyArgs.Add("idno", "");
            BodyArgs.Add("what", section.GetValue<string>("What"));
            BodyArgs.Add("field", section.GetValue<string>("Field"));
            BodyArgs.Add("search", section.GetValue<string>("Search"));
            BodyArgs.Add("apitoken", section.GetValue<string>("APIToken"));

            HRMSParameter param = new() { BodyArgs = BodyArgs, Urls = Urls };
            return new HRMSAdapter(param);
        }

    }
}
