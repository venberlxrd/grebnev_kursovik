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
    
    public partial class SystemUser
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string Role { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
