using System;
using ExcelClient.ExcelWebService;
using System.Web.Services.Protocols;

namespace SampleApplication
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Instantiate the Web service and create a status array object and range coordinate object
            ExcelService es = new ExcelService();
            Status[] outStatus;

            string sheetName = "Sheet1";

            string targetWorkbookPath = "http://chiron/codedemo/Excel/Provision.xlsx";

            //Set credentials for requests
            es.Credentials = System.Net.CredentialCache.DefaultCredentials;
            try
            {
                //Call open workbook, and point to the trusted   
                //location of the workbook to open.
                string sessionId = es.OpenWorkbook(targetWorkbookPath, "en-US", "en-US", out outStatus);

                
                // Set the input parameter
                es.SetCellA1(sessionId, sheetName, "Provisionssatz", "10");
                es.SetCellA1(sessionId, sheetName, "Umsatz", "1000");

                // Recalculate
                es.CalculateWorkbook(sessionId, CalculateType.Recalculate);
                

                // Get the return value
                
                object result = es.GetCellA1(sessionId, sheetName, "Provision", true, out outStatus);


                // Access a range of cells
                object[] rangeResult = es.GetRangeA1(sessionId, sheetName, "F1:F3", true, out outStatus);

                foreach (object row in rangeResult)
                {
                    foreach (object cell in (object[]) row)
                        Console.Write(cell + " ");

                    Console.WriteLine();
                }


                //Close workbook. This also closes session.
                es.CloseWorkbook(sessionId);
            }
            catch (SoapException e)
            {
                Console.WriteLine("SOAP Exception Message: {0}", e.Message);
            }
        }
    }
}
