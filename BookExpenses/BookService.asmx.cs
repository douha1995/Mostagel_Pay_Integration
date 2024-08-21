using BookExpenses.Models;
using BookExpenses.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace BookExpenses
{
    /// <summary>
    /// Summary description for BookService
    /// </summary>
    [WebService(Namespace = "webservice_url")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookService : System.Web.Services.WebService
    {

        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;
            string logFilePath = "F:\\web services\\logfiles\\FOLDER NAME\\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Inquiry(string fac_id)
        {
            string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
            var data = InvoiceDbClient.getEdBookInvoice(conn.ToString(), fac_id);
            
            return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

            /*JavaScriptSerializer js = new JavaScriptSerializer();
            string json_data = js.Serialize(data).ToString();
            return json_data;*/
        }

        /*[WebMethod]
        public string Inquiry(int fac_id)
        {

            string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            return conn;
            //var data = InvoiceDbClient.getEdBookInvoice(conn.ToString(), fac_id);
            //return data;
        }*/

        [WebMethod]
        public string Payment(string Billing_account, string BillNumber, string TransactionId, string TransactionDate,
                                string settellmentDate, string BankCode, string BranchCode, string PaidAmount, string SettelmentAcc,
                                string Currency, string ISDELETED, string STATUS, string acad_year,
                                string fac_id, string phase_id, string semester_id, string dept_id)
        {
            PaymentDetailsModel model = new PaymentDetailsModel();
            model.BillingAccount = Billing_account;
            model.BillNumber = BillNumber;
            model.TransactionId = TransactionId;
            model.TransactionDate = TransactionDate;
            model.settellmentDate = settellmentDate;
            model.BankCode = BankCode;
            model.BranchCode = BranchCode;
            model.PaidAmount = PaidAmount;
            model.SettelmentAcc = SettelmentAcc;
            model.Currency = Currency;
            model.ISDELETED = ISDELETED;
            model.STATUS = STATUS;
            model.Acad_year_id = acad_year;
            model.fac_code = fac_id;
            model.ED_CODE_SEMESTER_ID = semester_id;
            model.ED_CODE_PHASE_ID = phase_id;
            model.depart_id = dept_id;
            try
            {
                string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
                string data = InvoiceDbClient.payEdBookInvoice(model, conn);
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //string json_data = js.Serialize(data).ToString();
                return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception c)
            {
                string data = "connection error";
                return JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            }
        }

    }
}
