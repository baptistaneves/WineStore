using FluentValidation;
using FluentValidation.Results;
using WineStore.Core.DomainObjects;

namespace WineStore.Vendas.Domain
{
    public class Voucher : Entity
    {
        public string Codigo { get; private set; }

        public decimal? Percentual { get; private set; }

        public decimal? ValorDesconto { get; private set; }

        public int Quantidade { get; private set; }

        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataUtilizacao { get; private set; }

        public DateTime DataValidade { get; private set; }

        public bool Ativo { get; private set; }

        public bool Utilizado { get; private set; }

        //EF Rel.
        public ICollection<Pedido> Pedidos { get; set; }

        internal ValidationResult ValidarSeAplicavel()
        {
            return new VoucherAplicavelValidation().Validate(this);
        }
    }

    public class VoucherAplicavelValidation : AbstractValidator<Voucher>
    {
        public VoucherAplicavelValidation()
        {
            RuleFor(c => c.DataValidade)
                .Must((date) => date >= DateTime.Now)
                .WithMessage("Este voucher esta expirado");

            RuleFor(c => c.Ativo)
                .Equal(true)
                .WithMessage("Este voucher não é mais valido");

            RuleFor(c => c.Utilizado)
                .Equal(false)
                .WithMessage("Este voucher já foi utilizado");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("Este voucher não está mais disponível");
        }
    }
}
