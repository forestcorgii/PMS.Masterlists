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
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; } = string.Empty;

        public string NameExtension { get; set; } = string.Empty;

        public string Fullname
        {
            get
            {
                string lastname = LastName;
                string firstname = FirstName != string.Empty ? $", {FirstName}" : "";
                string middleInitial = MiddleName != string.Empty ? $" {MiddleName?[0]}" : "";
                string nameExtension = NameExtension != string.Empty ? $" {NameExtension}" : "";
                string fullName = $"{lastname}{firstname}{middleInitial}{nameExtension}.";

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


        public string Pagibig { get; set; }

        public string PhilHealth { get; set; }

        public string SSS { get; set; }

        public string TIN { get; set; }




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



        public string CardNumber { get; set; } = string.Empty;

        public string AccountNumber { get; set; } = string.Empty;

        public BankChoices Bank { get; set; }
        public string BankSetter
        {
            set
            {
                if (value == "LANDBANK" || value == "LBP")
                    Bank = BankChoices.LBP;
                else if (value == "CHINABANK" || value == "CBC")
                    Bank = BankChoices.CBC;
                else if (value == "CBC1")
                    Bank = BankChoices.CBC1;
                else if (value == "MPALO")
                    Bank = BankChoices.MPALO;
                else if (value == "MTAC")
                    Bank = BankChoices.MTAC;
                else if (value == "CHK")
                    Bank = BankChoices.CHK;
                else
                    Bank = BankChoices.UNKNOWN;
            }
        }



        public void ValidateAll()
        {
            ValidatePersonalInformation();
            ValidateBankInformation();
            ValidateGovernmentInformation();
        }


        public void ValidatePersonalInformation()
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
        }

        public void ValidateBankInformation()
        {
            if (Bank != BankChoices.CHK && AccountNumber == string.Empty)
                throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId, "Should not be blank.");
            if (AccountNumber.Any(char.IsLetter))
                throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);

            switch (Bank)
            {
                case BankChoices.LBP:
                    if (CardNumber is not null && CardNumber != string.Empty)
                    {
                        if (CardNumber.Length != 16)
                            throw new InvalidEmployeeFieldValueException(nameof(CardNumber), CardNumber, EEId);
                        if (CardNumber.Any(char.IsLetter))
                            throw new InvalidEmployeeFieldValueException(nameof(CardNumber), CardNumber, EEId);
                    }
                    else
                        throw new InvalidEmployeeFieldValueException(nameof(CardNumber), CardNumber, EEId, "Should not be blank.");

                    if (AccountNumber.Length != 19)
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);
                    if (!AccountNumber.Contains("19372"))
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId, "LBP Account numbers contains '19372'.");
                    break;

                case BankChoices.CBC:
                case BankChoices.CBC1:
                    var validLengths = new int[] { 10, 12, 18, 19 };
                    if (!validLengths.Contains(AccountNumber.Length))
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId,"CBC/CBC1 only accepts 10, 12, 18, 19 digit account numbers.");
                    break;

                case BankChoices.MTAC:
                    if (AccountNumber.Length != 13)
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);
                    if (AccountNumber.Substring(0, 3) != "525")
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId, "MTAC Account numbers have leading '525'.");
                    break;

                case BankChoices.MPALO:
                    if (AccountNumber.Length != 13)
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId);
                    if (AccountNumber.Substring(0, 3) != "756")
                        throw new InvalidEmployeeFieldValueException(nameof(AccountNumber), AccountNumber, EEId, "MPALO Account numbers have leading '756'.");
                    break;
                case BankChoices.UNKNOWN:
                    throw new InvalidEmployeeFieldValueException(nameof(Bank), Bank.ToString(), EEId);
            }
        }

        public void ValidateGovernmentInformation()
        {
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
                if (!Regex.IsMatch(TIN, @"^(\d{3}-\d{2}-\d{4}|\d{3}-\d{3}-\d{3}|\d{3}-\d{3}-\d{3}-\d{3}|[0-9]{9}|[0-9]{9}0{1,4})$"))
                    throw new InvalidEmployeeFieldValueException(nameof(TIN), TIN, EEId);
                if (TIN.Any(char.IsLetter)) throw new InvalidEmployeeFieldValueException(nameof(TIN), TIN, EEId);

            }

        }

    }
}
