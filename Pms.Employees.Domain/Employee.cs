using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pms.Employees.Domain
{
    public class Employee : IGeneralInformation, IBankInformation
    {
        [JsonProperty("idNo")]
        public string EEId { get; set; } = String.Empty;


        [JsonProperty("first_name")]
        public string FirstName { get; set; } = String.Empty;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = String.Empty;
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; } = String.Empty;
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
        public string Location { get; set; } = String.Empty;

        [JsonProperty("job_location")]
        public string Site { get; set; } = String.Empty;

        [JsonProperty("payroll_code")]
        public string PayrollCode { get; set; } = String.Empty;

        [JsonProperty("bank_category")]
        public string BankCategory { get; set; } = String.Empty;

        [JsonProperty("pagibig")]
        public string Pagibig { get; set; } = String.Empty;

        [JsonProperty("philhealth")]
        public string PhilHealth { get; set; } = String.Empty;

        [JsonProperty("sss")]
        public string SSS { get; set; } = String.Empty;

        [JsonProperty("tin")]
        public string TIN { get; set; } = String.Empty;


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

        public DateTime DateModified { get; set; } = DateTime.Now;
        public DateTime DateCreated { get; set; } = DateTime.Now;



        [JsonProperty("bank_name")]
        public string BankName { get; set; } = String.Empty;

        [JsonProperty("card_number")]
        public string CardNumber { get; set; } = String.Empty;

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = String.Empty;
    }
}
