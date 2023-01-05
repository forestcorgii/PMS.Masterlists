using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pms.Masterlists.ServiceLayer.HRMS.Exceptions;

namespace Pms.Masterlists.ServiceLayer.HRMS.Adapter
{
    public class HRMSAdapter
    {
        private HttpClient Client = new HttpClient();
        private HRMSParameter Parameter;

        public HRMSAdapter(HRMSParameter hrmsParameter)
        {
            Client = new HttpClient();
            Client.Timeout = TimeSpan.FromSeconds(30d);

            Parameter = hrmsParameter;

        }

        public async Task<T> GetEmployeeFromHRMS<T>(string eeId, string site)
        {
            try
            {
                Parameter.BodyArgs["idno"] = eeId;
                Parameter.BodyArgs["field"] = "acctg";
                var content = new FormUrlEncodedContent(Parameter.BodyArgs);

                var response = await Client.PostAsync(Parameter.Urls[site], content);

                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var jsonSettings = new JsonSerializerSettings();
                    jsonSettings.NullValueHandling = NullValueHandling.Ignore;

                    HRMSResponse<T> employee = JsonConvert.DeserializeObject<HRMSResponse<T>>(responseString, jsonSettings);
                    if (employee is not null)
                        return employee.message[0];
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case (System.Net.HttpStatusCode)400:
                            throw new InvalidRequestException();
                        case (System.Net.HttpStatusCode)404:
                            throw new EmployeeNotFoundException(eeId);
                    }
                }
            }
            catch (InvalidRequestException) { }
            catch (EmployeeNotFoundException) { }
            return default;
        }



        public async Task<IEnumerable<T>> GetNewlyHiredEmployeesFromHRMS<T>(DateTime fromDate, string site)
        {
            try
            {
                Parameter.BodyArgs["field"] = "newlyhired";
                Parameter.BodyArgs["joined_date_start"] = fromDate.ToString("yyyy-MM-dd");
                var content = new FormUrlEncodedContent(Parameter.BodyArgs);

                var response = await Client.PostAsync(Parameter.Urls[site], content);

                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var jsonSettings = new JsonSerializerSettings();
                    jsonSettings.NullValueHandling = NullValueHandling.Ignore;

                    HRMSResponse<T> employee = JsonConvert.DeserializeObject<HRMSResponse<T>>(responseString, jsonSettings);
                    if (employee is not null)
                        return employee.message;
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case (System.Net.HttpStatusCode)400:
                            throw new InvalidRequestException();
                        //case (System.Net.HttpStatusCode)404:
                        //    throw new EmployeeNotFoundException(eeId);
                    }
                }
            }
            catch (InvalidRequestException) { }
            catch (EmployeeNotFoundException) { }
            return default;
        }


        public async Task<IEnumerable<T>> GetResignedEmployeesFromHRMS<T>(DateTime fromDate, string site)
        {
            try
            {
                Parameter.BodyArgs["field"] = "resigned";
                Parameter.BodyArgs["resigned_date_start"] = fromDate.ToString("yyyy-MM-dd");
                var content = new FormUrlEncodedContent(Parameter.BodyArgs);

                var response = await Client.PostAsync(Parameter.Urls[site], content);

                string responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var jsonSettings = new JsonSerializerSettings();
                    jsonSettings.NullValueHandling = NullValueHandling.Ignore;

                    HRMSResponse<T> employee = JsonConvert.DeserializeObject<HRMSResponse<T>>(responseString, jsonSettings);
                    if (employee is not null)
                        return employee.message;
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case (System.Net.HttpStatusCode)400:
                            throw new InvalidRequestException();
                        //case (System.Net.HttpStatusCode)404:
                        //    throw new EmployeeNotFoundException(eeId);
                    }
                }
            }
            catch (InvalidRequestException) { }
            catch (EmployeeNotFoundException) { }
            return default;
        }

        public class HRMSResponse<T>
        {
            public List<T> message = new();
            public string code = "";
        }
    }
}
