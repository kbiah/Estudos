using lagrimas.Modelo.Cadastros;

namespace lagrimas.Modelo.Cadastros
{
    public class Departamento
    {

        // long? = aceita valor nulo
        public long? DepartamentoID { get; set; }
        public string Nome { get; set; }

        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }
    }
}