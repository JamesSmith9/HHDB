using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMembership.Models
{
    public class HighchartsAnswerViewModel
    {
        public int SXQID { get; set; }
        public string AnsText { get; set; }
        public System.Guid CreatedByUser { get; set; }
        public int AnswerID { get; set; }
        public short Month { get; set; }
        public short Year { get; set; }
        public int Quantity { get; set; }

    }
}