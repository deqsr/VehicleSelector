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
    
    public partial class PartImage
    {
        public int id { get; set; }
        public byte[] image { get; set; }
    
        public virtual Part Part { get; set; }
    }
}
