using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BookExpenses.Models;
using BookExpenses.Utitlity;
namespace BookExpenses.Translators
{
    public static class InvoiceExpensesTranslator
    {
        public static InvoiceModel TranslateAsInvoice(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var invoice = new InvoiceModel();

            if (reader.IsColumnExists("stud_code"))
                invoice.stud_code = SqlHelper.GetNullableString(reader, "stud_code");

            if (reader.IsColumnExists("stud_name"))
                invoice.stud_name = SqlHelper.GetNullableString(reader, "stud_name");

            if (reader.IsColumnExists("fac_name"))
                invoice.fac_name = SqlHelper.GetNullableString(reader, "fac_name");

            if (reader.IsColumnExists("node_desc"))
                invoice.node_desc = SqlHelper.GetNullableString(reader, "node_desc");

            if (reader.IsColumnExists("phase_desc"))
                invoice.phase_desc = SqlHelper.GetNullableString(reader, "phase_desc");

            if (reader.IsColumnExists("depart_id"))
                invoice.depart_id = SqlHelper.GetNullableInt32(reader, "depart_id");

            if (reader.IsColumnExists("AS_NODE_DESC"))
                invoice.AS_NODE_DESC = SqlHelper.GetNullableString(reader, "AS_NODE_DESC");

            if (reader.IsColumnExists("Acad_year_id"))
                invoice.Acad_year_id = SqlHelper.GetNullableInt32(reader, "Acad_year_id");

            if (reader.IsColumnExists("fac_code"))
                invoice.fac_code = SqlHelper.GetNullableInt32(reader, "fac_code");

            if (reader.IsColumnExists("year_order"))
                invoice.Year_Order = SqlHelper.GetNullableInt32(reader, "Year_Order");

            if (reader.IsColumnExists("TotalAmount"))
                invoice.TotalAmount = SqlHelper.GetDouble(reader, "TotalAmount");

            if (reader.IsColumnExists("ED_CODE_PHASE_ID"))
                invoice.ED_CODE_PHASE_ID = SqlHelper.GetNullableInt32(reader, "ED_CODE_PHASE_ID");

            if (reader.IsColumnExists("EdStudScholasticId"))
                invoice.EdStudScholasticId = SqlHelper.GetNullableInt32(reader, "EdStudScholasticId");

            if (reader.IsColumnExists("ED_CODE_SEMESTER_ID"))
                invoice.ED_CODE_SEMESTER_ID = SqlHelper.GetNullableInt32(reader, "ED_CODE_SEMESTER_ID");

            if (reader.IsColumnExists("BOOK_EXP_ID"))
                invoice.BOOK_EXP_ID = SqlHelper.GetNullableInt32(reader, "BOOK_EXP_ID");

            if (reader.IsColumnExists("BOOK_EXP_NAME"))
                invoice.BOOK_EXP_NAME = SqlHelper.GetNullableString(reader, "BOOK_EXP_NAME");

            if (reader.IsColumnExists("Semester_Order"))
                invoice.Semester_Order = SqlHelper.GetNullableInt32(reader, "Semester_Order");


            return invoice;
        }

        public static List<InvoiceModel> TranslateAsEdBookList(this SqlDataReader reader)
        {
            var list = new List<InvoiceModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsInvoice(reader, true));
            }
            return list;
        }
    }
}