using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Pms.Masterlists.Domain;
using Pms.Masterlists.Domain.Entities.Employees;
using Pms.Masterlists.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Masterlists.ServiceLayer.Files
{
    public class InvalidValueReporter
    {


        public void StartReport(IEnumerable<Exception> exceptions, PayrollCode payrollCode, string suffix)
        {
            IWorkbook nWorkbook = new HSSFWorkbook();
            ISheet nSheet = nWorkbook.CreateSheet("Sheet1");


            int rowIndex = -1;

            WriteHeader(nSheet.CreateRow(Append(ref rowIndex)));
            foreach (Exception exception in exceptions)
            {
                if (exception is InvalidFieldValueException invalidValueException)
                    WriteRow(nSheet.CreateRow(Append(ref rowIndex)), invalidValueException.EEId, invalidValueException.Message);
                else if (exception is InvalidFieldValuesException invalidValuesException)
                    WriteRow(nSheet.CreateRow(Append(ref rowIndex)), invalidValuesException.EEId, invalidValuesException.Detail);
                else if (exception is DuplicateBankInformationException dupBankInformationException)
                    WriteRow(nSheet.CreateRow(Append(ref rowIndex)), "", dupBankInformationException.Message);
                else
                    WriteRow(nSheet.CreateRow(Append(ref rowIndex)), "", exception.Message);
            }



            string filedirectory = $@"{AppDomain.CurrentDomain.BaseDirectory}\EXPORT\ERROR LOG";
            Directory.CreateDirectory(filedirectory);

            string filename = $"ERROR-ALL";
            if (payrollCode.PayrollCodeId != string.Empty)
                filename = $"ERROR-{payrollCode.PayrollCodeId}";

            string fullname = $@"{filedirectory}\{filename}-{DateTime.Now:yyyyMMdd}-{suffix}.xls";

            using (var nReportFile = new FileStream(fullname, FileMode.OpenOrCreate, FileAccess.Write))
                nWorkbook.Write(nReportFile);
        }


        private void WriteHeader(IRow row)
        {
            int cellIndex = -1;
            row.CreateCell(Append(ref cellIndex)).SetCellValue("#");
            row.CreateCell(Append(ref cellIndex)).SetCellValue("EE ID");
            row.CreateCell(Append(ref cellIndex)).SetCellValue("ERROR MESSAGE");
        }

        private void WriteRow(IRow row, string eeId, string errorMessage)
        {
            int cellIndex = -1;
            row.CreateCell(Append(ref cellIndex)).SetCellValue(row.RowNum);
            row.CreateCell(Append(ref cellIndex)).SetCellValue(eeId);
            row.CreateCell(Append(ref cellIndex)).SetCellValue(errorMessage);
        }


        private static int Append(ref int index)
        {
            index++;
            return index;
        }

    }
}
