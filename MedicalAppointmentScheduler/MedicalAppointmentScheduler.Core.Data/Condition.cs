
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MedicalAppointmentScheduler.Core.Data
{

using System;
    using System.Collections.Generic;
    
public partial class Condition
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Condition()
    {

        this.User_Details = new HashSet<UserDetails>();

    }


    public int ID { get; set; }

    public int Type_ID { get; set; }

    public string Name { get; set; }



    public virtual Type Type { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<UserDetails> User_Details { get; set; }

}

}