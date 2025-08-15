namespace Pyro.Models
{
    public class UserPostModel
    {
        public Models.UsuarioModel? Usuario { get; set; }
        public List<Models.PostModel>? Posts { get; set; }
        public List<string> Authors { get; set; }

        public List<string> Names { get; set; }
    }
}
