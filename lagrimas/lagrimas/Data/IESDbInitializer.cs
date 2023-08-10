using System.Data.Entity;
using System.Linq;
using lagrimas.Models;

namespace lagrimas.Data
{
    public class IESDbInitializer
    {
        public static void Initialize(IESContext context)
        {
            context.Database.EnsureDeleted();
            // add this to ensure new tables,colums are created
            context.Database.EnsureCreated();

            if (context.Departamentos.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao { Nome="UniParaná", Endereco="Paraná"},
                new Instituicao { Nome="UniAcre", Endereco="Acre"}
            };

            foreach (Instituicao i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();

            var departamentos = new Departamento[]
            {
                new Departamento { Nome="Ciência da Computação", InstituicaoID=1 },
                new Departamento { Nome="Ciência de Alimentos", InstituicaoID=2}
            };
            foreach (Departamento d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();
        }
    }
}
