//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rent_car
{
    using System;
    using System.Collections.Generic;
    
    public partial class RentCar
    {
        public int id { get; set; }
        public int idCar { get; set; }
        public int idUser { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Users Users { get; set; }
    }
}
