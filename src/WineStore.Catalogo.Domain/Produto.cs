using WineStore.Core.DomainObjects;

namespace WineStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public string Imagem { get; private set; }

        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Produto() { }
        public Produto(string nome, string descricao, decimal valor, Guid categoriaId, bool ativo, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            CategoriaId = categoriaId;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Desativar() => Ativo = false;
        public void Ativar() => Ativo = true;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao do produto nao pode ser vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque Insuficiente!");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto nao pode ser vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto nao pode ser vazio");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto nao pode ser vazio");
            Validacoes.ValidarSeIgual(Valor, 0, "O campo Valor do produto nao pode ser igual a 0");
            Validacoes.ValidarSeMenorQue(Valor, 0, "O campo Valor do produto nao pode ser menor que 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto nao pode ser vazio");
        }
    }
}

