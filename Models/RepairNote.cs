//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Course_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepairNote
    {
        public int RepairNoteID { get; set; }
        public int RepairCompanyID { get; set; }
        public int InventoryID { get; set; }
        public decimal RepairCost { get; set; }
        public System.DateTime RepairDate { get; set; }
        public string Notes { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual RepairCompany RepairCompany { get; set; }
    }
}
