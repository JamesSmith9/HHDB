//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleMembership
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyXQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SurveyXQuestion()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public int SXQID { get; set; }
        public int QuestionID { get; set; }
        public int SurveyID { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual Survey Survey { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
