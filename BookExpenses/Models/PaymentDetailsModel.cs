using System;
using System.Runtime.Serialization;

namespace BookExpenses.Models
{
    [DataContract]
    public class PaymentDetailsModel
    {
        [System.Runtime.Serialization.DataMember(Name = "BillingAccount")]
        public string BillingAccount { get; set; }

        [DataMember(Name = "BillNumber")]
        public string BillNumber { get; set; }

        [DataMember(Name = "TransactionId")]
        public string TransactionId { get; set; }

        [DataMember(Name = "TransactionDate")]
        public string TransactionDate { get; set; }

        [DataMember(Name = "settellmentDate")]
        public string settellmentDate { get; set; }

        [DataMember(Name = "BankCode")]
        public string BankCode { get; set; }

        [DataMember(Name = "BranchCode")]
        public string BranchCode { get; set; }

        [DataMember(Name = "PaidAmount")]
        public string PaidAmount { get; set; }

        [DataMember(Name = "SettelmentAcc")]
        public string SettelmentAcc { get; set; }

        [DataMember(Name = "Currency")]
        public string Currency { get; set; }

        [DataMember(Name = "ISDELETED")]
        public string ISDELETED { get; set; }

        [DataMember(Name = "STATUS")]
        public string STATUS { get; set; }

        [DataMember(Name = "year_id")]
        public string Acad_year_id { get; set; }

        [DataMember(Name = "faculty_code")]
        public string fac_code { get; set; }

        [DataMember(Name = "level_id")]
        public string ED_CODE_PHASE_ID { get; set; }

        [DataMember(Name = "semester_id")]
        public string ED_CODE_SEMESTER_ID { get; set; }

        [DataMember(Name = "depart_id")]
        public string depart_id { get; set; }


    }
}