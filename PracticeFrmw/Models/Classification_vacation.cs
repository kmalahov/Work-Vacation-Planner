//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticeFrmw.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Classification_vacation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classification_vacation()
        {
            this.Application_for_vacation = new HashSet<Application_for_vacation>();
        }
    
        public int id_classification_vacation { get; set; }
        public string code_classification { get; set; }
        public string name_classification { get; set; }
        public int period_vacation { get; set; }
        public int usage_count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Application_for_vacation> Application_for_vacation { get; set; }
    }
}