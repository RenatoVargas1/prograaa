//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acceso
    {
        public string Id { get; set; }
        public string contraseña { get; set; }
        public string UsuarioDni { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
