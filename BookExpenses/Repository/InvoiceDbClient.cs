using BookExpenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookExpenses.Utitlity;
using BookExpenses.Translators;

namespace BookExpenses.Repository
{
    public static class InvoiceDbClient
    {
        public static  List<InvoiceModel> getEdBookInvoice(string constring, string parameter)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<InvoiceModel>>
                (constring, r => r.TranslateAsEdBookList(), parameter);

        }

        public static string payEdBookInvoice(PaymentDetailsModel model, string connString)
        {
            var outParam = new SqlParameter("@STATUSMESSAGE", System.Data.SqlDbType.NVarChar, 20)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter[] param = {
        new SqlParameter("@BillingAccount",model.BillingAccount),
        new SqlParameter("@BillNumber",model.BillNumber),
        new SqlParameter("@TransactionId",model.TransactionId),
        new SqlParameter("@TransactionDate",model.TransactionDate),
        new SqlParameter("@settellmentDate",model.settellmentDate),
        new SqlParameter("@BankCode",model.BankCode),
        new SqlParameter("@BranchCode",model.BranchCode),
        new SqlParameter("@PaidAmount",model.PaidAmount),
        new SqlParameter("@SettelmentAcc",model.SettelmentAcc),
        new SqlParameter("@Currency",model.Currency),
        new SqlParameter("@ISDELETED",model.ISDELETED),
        new SqlParameter("@STATUS",model.STATUS),
        new SqlParameter("@Acad_year_id",model.Acad_year_id),
        new SqlParameter("@fac_code",model.fac_code),
        new SqlParameter("@ED_CODE_PHASE_ID",model.ED_CODE_PHASE_ID),
        new SqlParameter("@ED_CODE_SEMESTER_ID",model.ED_CODE_SEMESTER_ID),
        new SqlParameter("@depart_id",model.depart_id),
        //new SqlParameter("@STATUSMESSAGE",model.STATUSMESSAGE),
        outParam
    };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_Books_PaymentNotification", param);
            return (string)outParam.Value;
        }
    }
}