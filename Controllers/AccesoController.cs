using Microsoft.AspNetCore.Mvc;
using BuildTrackSeven.Data;
using BuildTrackSeven.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BuildTrackSeven.ViewModels;

namespace BuildTrackSeven.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDBContext _appDbContext;

        // Constructor con inyección de dependencias
        public AccesoController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;  
        }

        //Get y Post para el formulario de inicio de sesion

        [HttpGet]        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginVM modelo)
        {
            //Obtiene el primer registro que cumpla con la condición. Si no se encuentra, devolverá null
            Usuario? usuario_encontrado = await _appDbContext.Usuarios.Where(u => 
            u.Nusuario == modelo.Nusuario && u.Contrasenia == modelo.Contrasenia).FirstOrDefaultAsync();

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se puede encontrar coincidencias";
                return View();
            }

            // Verifica el rol del usuario
            if (usuario_encontrado.Rol == "Administrador")
            {
                return RedirectToAction("Index", "Home");  // Redirige a la vista del Admin
            }
            else if (usuario_encontrado.Rol == "Cliente")
            {
                return RedirectToAction("Privacy", "Home");  // Redirige a la vista del Cliente
            }

            return RedirectToAction("Login","Acceso");
        }
       
    }
}
