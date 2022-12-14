using FluentValidation;
using WineStore.Core.Messages;

namespace WineStore.Vendas.Application.Commands
{
    public class AplicarVoucherPedidoCommand : Command
    {
        public Guid ClienteId { get; private set; }
        public string VoucherCodigo { get; private set; }

        public AplicarVoucherPedidoCommand(Guid clienteId, string voucherCodigo)
        {
            ClienteId = clienteId;
            VoucherCodigo = voucherCodigo;
        }

        public override bool EhValido()
        {
            ValidationResult = new AplicarVoucherPedidoValidation().Validate(instance: this);
            return ValidationResult.IsValid;
        }
    }

    public class AplicarVoucherPedidoValidation : AbstractValidator<AplicarVoucherPedidoCommand>
    {
        public AplicarVoucherPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.VoucherCodigo)
                .NotEmpty()
                .WithMessage("Codigo do voucher não pode ser vazio");
        }
    }
}
