using System;
using System.Runtime.Serialization;

namespace BookExpenses.Models
{
    [DataContract]
    public class InvoiceModel
    {
        [DataMember(Name = "student_code")]
        public String stud_code { get; set; }

        [DataMember(Name = "student_name")]
        public String stud_name { get; set; }

        [DataMember(Name = "faculty_name")]
        public String fac_name { get; set; }

        [DataMember(Name = "semester_desc")]
        public String node_desc { get; set; }

        [DataMember(Name = "level_desc")]
        public String phase_desc { get; set; }

        [DataMember(Name = "depart_id")]
        public int depart_id { get; set; }

        [DataMember(Name = "depart_desc")]
        public String AS_NODE_DESC { get; set; }

        [DataMember(Name = "year_id")]
        public int Acad_year_id { get; set; }

        [DataMember(Name = "faculty_code")]
        public int fac_code { get; set; }

        [DataMember(Name = "year_order")]
        public int Year_Order { get; set; }

        [DataMember(Name = "book_price")]
        public double TotalAmount { get; set; }

        [DataMember(Name = "level_id")]
        public int ED_CODE_PHASE_ID { get; set; }

        [DataMember(Name = "ed_scholastic_id")]
        public int EdStudScholasticId { get; set; }

        [DataMember(Name = "semester_id")]
        public int ED_CODE_SEMESTER_ID { get; set; }

        [DataMember(Name = "book_exp_id")]
        public int BOOK_EXP_ID { get; set; }

        [DataMember(Name = "book_exp_name")]
        public String BOOK_EXP_NAME { get; set; }

        [DataMember(Name = "semester_order")]
        public int Semester_Order { get; set; }

    }
}