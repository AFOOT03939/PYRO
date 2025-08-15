using Microsoft.AspNetCore.Mvc;
using Pyro.Models;
using Pyro.Models.DB;
using System.Diagnostics;

namespace Pyro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View(Usuariolocal);
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static Models.UsuarioModel? Usuariolocal { get; set; }

        public IActionResult BuscarUsuario(string apodo, string contrasena)
        {
            using (var db = new Models.DB.PyroBdContext())
            {

                var usuario = (from d in db.Usuarios
                               where d.ApodoUsuario == apodo && d.ContraUsuario == contrasena && d.EstadoUsuario == 1
                               select new Models.UsuarioModel
                               {
                                   IdUsuario = d.IdUsuario,
                                   ContraUsuario = d.ContraUsuario,
                                   EstadoUsuario = d.EstadoUsuario,
                                   FechaUsuario = d.FechaUsuario,
                                   ApodoUsuario = d.ApodoUsuario
                               }).FirstOrDefault();
                Usuariolocal = usuario;
                if (usuario != null)
                {
                    Usuariolocal = usuario;
                    ViewBag.Message = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Usuariolocal = usuario;
                    ViewBag.Message = "Credenciales inválidas. Inténtelo nuevamente.";
                    return View("Login");
                }
            }
        }

        public IActionResult MostrarPosts()
        {
            List<Post> content = new List<Post>();

            using (var db = new Models.DB.PyroBdContext())
            {
                content = db.Posts.ToList();
            }
            return RedirectToAction("Index", "Home", content);
        }

        public IActionResult AgregarUsuario(string apodo, string contrasena)
        {
            if (apodo == null || contrasena == null)
            {
                ViewBag.Message = "Por favor, rellena todos los campos.";
                return View("Register");
            }

            using (var db = new Models.DB.PyroBdContext())
            {
                var usuario = (from d in db.Usuarios
                               where d.ApodoUsuario == apodo && d.EstadoUsuario == 1
                               select new Models.UsuarioModel
                               {
                                   IdUsuario = d.IdUsuario,
                                   ApodoUsuario = d.ApodoUsuario,
                                   ContraUsuario = d.ContraUsuario,
                                   EstadoUsuario = d.EstadoUsuario,
                                   FechaUsuario = d.FechaUsuario
                               }).FirstOrDefault();
                if (usuario != null)
                {
                    ViewBag.Message = "Nombre de usuario ya existente; ingrese otro nombre";
                    return View("Register");
                }

                var nuevoUsuario = new Models.DB.Usuario
                {
                    ApodoUsuario = apodo,
                    ContraUsuario = contrasena,
                    EstadoUsuario = 1
                };

                db.Add(nuevoUsuario);
                db.SaveChanges();
                Usuariolocal = (from d in db.Usuarios
                                where d.IdUsuario == nuevoUsuario.IdUsuario
                                select new Models.UsuarioModel
                                {
                                    IdUsuario = d.IdUsuario,
                                    ApodoUsuario = d.ApodoUsuario,
                                    ContraUsuario = d.ContraUsuario,
                                    EstadoUsuario = d.EstadoUsuario,
                                    FechaUsuario = d.FechaUsuario
                                }).FirstOrDefault();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {

            var usuario = Usuariolocal;
            List<PostModel> pub = new List<PostModel>();
            List<string> autores = new List<string>();
            List<string> nombres = new List<string>();

            using (var db = new Models.DB.PyroBdContext())
            {
                var consulta =
                from p in db.Posts
                select new PostModel
                {
                    IdPost = p.IdPost,
                    DescPost = p.DescPost,
                    EstadoPost = p.EstadoPost,
                    FechaPost = p.FechaPost,
                    IdGrupo = p.IdGrupo,
                    IdUsuario = p.IdUsuario
                };

                pub = consulta.ToList();

                autores =
                (from post in pub
                 join u in db.Usuarios on post.IdUsuario equals u.IdUsuario
                 select u.ApodoUsuario).ToList();

                nombres = (from post in pub 
                           join u in db.Usuarios on post.IdUsuario equals u.IdUsuario
                           select u.ApodoUsuario).ToList();

            }

            var content = new UserPostModel
            {
                Usuario = usuario,
                Posts = pub,
                Authors = autores,
                Names = nombres
               
            };

            if (usuario == null)
            {
                ViewBag.Message = "NA";
                

            }
            return View(content);


        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CerrarSesion()
        {
            Usuariolocal = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
