namespace CepGestao.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string User { get; set; }

        public string Senha { get; set; }

        public List<Endereco> Enderecos { get; set; }
    }
}
