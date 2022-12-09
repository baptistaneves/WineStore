using WineStore.Core.DomainObjects;

namespace WineStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(Altura, 1, "Campo Altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Largura, 1, "Campo Largura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Profundidade, 1, "Campo Profundidade não pode ser menor ou igual a 0");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
