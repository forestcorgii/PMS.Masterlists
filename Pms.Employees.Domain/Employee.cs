using Newtonsoft.Json;
using Pms.Employees.Domain.Exceptions;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using static Pms.Employees.Domain.Enums;

namespace Pms.Employees.Domain
{
    public class Employee : IPersonalInformation, IBankInformation, IGovernmentInformation, IEEFileInformation
    {

        [JsonProperty("idNo")]
        public string EEId { get; set; }


        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        public string NameExtension { get; set; }

        public string Fullname
        {
            get
            {
                string lastname = LastName;
                string firstname = FirstName != string.Empty ? $", {FirstName}" : "";
                string nameExtension = NameExtension != string.Empty ? $" {NameExtension}" : "";
                string middleInitial = MiddleName != string.Empty ? $" {MiddleName[0]}" : "";
                string fullName = $"{lastname}{firstname}{nameExtension}{middleInitial}.";
                
                return fullName;
            }
        }

        public string Gender { get; set; }


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

        public void Validate()
        {
            if (EEId is not null && EEId != string.Empty)
            {
                if (EEId.Length < 3) throw new InvalidEmployeeFieldValueException(nameof(EEId), EEId, EEId);
                if (EEId.Length > 4) throw new InvalidEmployeeFieldValueException(nameof(EEId), EEId, EEId);
                if (EEId.Any(char.IsLower)) throw new InvalidEmployeeFieldValueException(nameof(EEId), EEId, EEId);
            }

            if (FirstName is not null && FirstName != string.Empty)
            {
                if (FirstName.Length < 2) throw new InvalidEmployeeFieldValueException(nameof(FirstName), FirstName, EEId);
                if (FirstName.Length > 45) throw new InvalidEmployeeFieldValueException(nameof(FirstName), FirstName, EEId);
                if (FirstName.Any(char.IsDigit)) throw new InvalidEmployeeFieldValueException(nameof(FirstName), FirstName, EEId);
                if (FirstName.Any(char.IsLower)) throw new InvalidEmployeeFieldValueException(nameof(FirstName), FirstName, EEId);
            }

            if (LastName is not null && LastName != string.Empty)
            {

                if (LastName.Length < 2) throw new InvalidEmployeeFieldValueException(nameof(LastName), LastName, EEId);
                if (LastName.Length > 45) throw new InvalidEmployeeFieldValueException(nameof(LastName), LastName, EEId);
                if (LastName.Any(char.IsDigit)) throw new InvalidEmployeeFieldValueException(nameof(LastName), LastName, EEId);
                if (LastName.Any(char.IsLower)) throw new InvalidEmployeeFieldValueException(nameof(LastName), LastName, EEId);
            }

            if (MiddleName is not null && MiddleName != string.Empty)
            {
                if (MiddleName.Length > 45) throw new InvalidEmployeeFieldValueException(nameof(MiddleName), MiddleName, EEId);
                if (MiddleName.Any(char.IsDigit)) throw new InvalidEmployeeFieldValueException(nameof(MiddleName), MiddleName, EEId);
                if (MiddleName.Any(char.IsLower)) throw new InvalidEmployeeFieldValueException(nameof(MiddleName), MiddleName, EEId);

            }

            if (Pagibig is not null && Pagibig != string.Empty)
            {
                if (!Regex.IsMatch(Pagibig, @"^(\d{4}-\d{4}-\d{4}|[0-9]{12})$"))
                    throw new InvalidEmployeeFieldValueException(nameof(Pagibig), Pagibig, EEId);
                if (Pagibig.Any(char.IsLetter)) throw new InvalidEmployeeFieldValueException(nameof(Pagibig), Pagibig, EEId);

            }

            if (PhilHealth is not null && PhilHealth != string.Empty)
            {
                if (!Regex.IsMatch(PhilHealth, @"^(\d{2}-\d{9}-\d|[0-9]{12})$"))
                    throw new InvalidEmployeeFieldValueException(nameof(PhilHealth), PhilHealth, EEId);
                if (PhilHealth.Any(char.IsLetter)) throw new InvalidEmployeeFieldValueException(nameof(PhilHealth), PhilHealth, EEId);

            }

            if (SSS is not null && SSS != string.Empty)
            {
                if (!Regex.IsMatch(SSS, @"^(\d{2}-\d{7}-\d|[0-9]{10})$"))
                    throw new InvalidEmployeeFieldValueException(nameof(SSS), SSS, EEId);
                if (SSS.Any(char.IsLetter)) throw new InvalidEmployeeFieldValueException(nameof(SSS), SSS, EEId);

            }

            if (TIN is not null && TIN != string.Empty)
            {
                if (!Regex.IsMatch(TIN, @"^(\d{3}-\d{2}-\d{4}|[0-9]{9}|[0-9]{9}0{1,4})$"))
                    throw new InvalidEmployeeFieldValueException(nameof(TIN), TIN, EEId);
                if (TIN.Any(char.IsLetter)) throw new InvalidEmployeeFieldValueException(nameof(TIN), TIN, EEId);

            }

            if (CardNumber is not null && CardNumber != string.Empty)
            {
                if (CardNumber.Length > 25)
                    throw new InvalidEmployeeFieldValueException(nameof(CardNumber), CardNumber, EEId);
                if (CardNumber.Any(char.IsLetter))
                    throw new InvalidEmployeeFieldValueException(nameof(CardNumber), CardNumber, EEId);
            }

            if (AccountNumber is not null && AccountNumber != string.Empty)
            {
                if (AccountNumber.Length > 20)
                    throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);
                if (AccountNumber.Any(char.IsLetter))
                    throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);
            }
        }


        public DateTime BirthDate { get; set; }

        [JsonProperty("birthdate")]
        public string BirthDateSetter
        {
            set
            {
                if (value == "" || value == "0000-00-00")
                    BirthDate = default;
                else
                {
                    DateTime birthDate;
                    if (DateTime.TryParse(value, out birthDate))
                        BirthDate = birthDate;
                    else if (DateTime.TryParseExact(value, new string[] { "MM/dd/yyyy", "M/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                        BirthDate = birthDate;
                    else
                        BirthDate = DateTime.Parse(value);
                }
            }
        }

        public bool Active { get; set; } = true;

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }



        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        public BankChoices Bank { get; set; }
        [JsonProperty("bank_name")]
        public string BankSetter
        {
            set
            {
                if (value == "LANDBANK" || value == "LBP")
                    Bank = BankChoices.LBP;
                else if (value == "CHINABANK" || value == "CBC")
                    Bank = BankChoices.LBP;
                else if (value == "MPALO")
                    Bank = BankChoices.MPALO;
                else if (value == "MTAC")
                    Bank = BankChoices.MTAC;
                else
                    Bank = BankChoices.CHK;
            }
        }

    }
}
