//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleSelector
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }
        public string color { get; set; }
        public int mileage { get; set; }
        public string condition { get; set; }
        public string type { get; set; }
    
        public virtual CarDescription CarDescription { get; set; }
        public virtual Image Image { get; set; }
    }
}
