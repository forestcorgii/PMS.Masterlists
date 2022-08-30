using Newtonsoft.Json;
using System; 

namespace Pms.Employees.Domain
{
    public class Employee : IPersonalInformation, IBankInformation,IGovernmentInformation
    {
        [JsonProperty("idNo")]
        public string EEId { get; set; } 


        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; } 
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        public string Fullname
        {
            get
            {
                if (FirstName is null || LastName is null) { return ""; }
                string _fullName = $"{LastName}, {FirstName}";
                if (MiddleName == "" || MiddleName is null) { _fullName = $"{_fullName}."; } else { _fullName = $"{_fullName} {MiddleName.Substring(0, 1)}."; }
                return _fullName;
            }
        }

        [JsonProperty("department")]
        public string Location { get; set; } 

        [JsonProperty("job_location")]
        public string Site { get; set; }

        [JsonProperty("payroll_code")]
        public string PayrollCode { get; set; }

        [JsonProperty("bank_category")]
        public string BankCategory { get; set; }

        [JsonProperty("pagibig")]
        public string Pagibig { get; set; }

        [JsonProperty("philhealth")]
        public string PhilHealth { get; set; } 

        [JsonProperty("sss")]
        public string SSS { get; set; } 

        [JsonProperty("tin")]
        public string TIN { get; set; } 


        public DateTime BirthDate { get; set; }

        [JsonProperty("birthdate")]
        public string BirthDateString
        {
            set
            {
                if (value == "0000-00-00")
                    BirthDate = default;
                else
                    BirthDate = DateTime.Parse(value);
            }
        }

        public bool Active { get; set; } = true;

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }



        [JsonProperty("bank_name")]
        public string BankName { get; set; } 

        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
    }
}
