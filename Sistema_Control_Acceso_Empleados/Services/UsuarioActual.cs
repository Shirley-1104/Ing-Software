using Sistema_Control_Acceso_Empleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Control_Acceso_Empleados.Services
{
    public static class UsuarioActual
    {
        public static Usuario UsuarioLogueado { get; set; }
    }
}
