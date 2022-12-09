using WineStore.Core.DomainObjects;

namespace WineStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        //EF Relation
        public ICollection<Produto> Produtos { get; private set; }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        protected Categoria() { }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto nao pode ser vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo do produto nao pode ser 0");
        }
    }
}

