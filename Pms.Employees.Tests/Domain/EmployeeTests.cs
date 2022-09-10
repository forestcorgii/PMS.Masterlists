using Pms.Employees.Domain;
using Pms.Employees.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pms.Employees.Tests.Domain
{
    public class EmployeeTests
    {
        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        [InlineData("QQQQQ")]
        public void ShouldThrowInvalidValueExceptionWhenSettingEEId(string eeId)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.EEId = eeId;
                employee.ValidateAll();
            });
        }

        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        public void ShouldThrowInvalidValueExceptionWhenSettingFirstName(string firstname)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.FirstName = firstname;
                employee.ValidateAll();
            });
        }

        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        public void ShouldThrowInvalidValueExceptionWhenSettingLastName(string lastname)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.LastName = lastname;
                employee.ValidateAll();
            });
        }

        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        public void ShouldThrowInvalidValueExceptionWhenSettingMiddleName(string middlename)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.MiddleName = middlename;
                employee.ValidateAll();
            });
        }


        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        [InlineData("QQQQQ")]
        public void ShouldThrowInvalidValueExceptionWhenSettingTIN(string tin)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.TIN = tin;
                employee.ValidateAll();
            });
        }


        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        [InlineData("QQQQQ")]
        public void ShouldThrowInvalidValueExceptionWhenSettingPagibig(string pagibig)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.Pagibig = pagibig;
                employee.ValidateAll();
            });
        }


        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        [InlineData("QQQQQ")]
        public void ShouldThrowInvalidValueExceptionWhenSettingPhilHealth(string philHealth)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.PhilHealth = philHealth;
                employee.ValidateAll();
            });
        }


        [Theory]
        [InlineData("qq")]
        [InlineData("qqqq")]
        [InlineData("QQQQQ")]
        public void ShouldThrowInvalidValueExceptionWhenSettingSSS(string sss)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.SSS = sss;
                employee.ValidateAll();
            });
        }


        [Theory]
        [InlineData("AAAAA1212")]
        [InlineData("11111111111111111111111111")]
        public void ShouldThrowInvalidValueExceptionWhenSettingCardNumber(string cardNumber)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.CardNumber = cardNumber;
                employee.ValidateAll();
            });
        }

        [Theory]
        [InlineData("AAAAA1212")]
        [InlineData("1111111111111111111111")]
        public void ShouldThrowInvalidValueExceptionWhenSettingAccountNumber(string accountNumber)
        {
            Assert.Throws<InvalidEmployeeFieldValueException>(() =>
            {
                Employee employee = new();
                employee.AccountNumber = accountNumber;
                employee.ValidateAll();
            });
        }



    }
}
