using FluentValidation.Results;
using MediatR;

namespace WineStore.Core.Messages
{
    public abstract class Command : Message, IRequest<bool>
    {
        public DateTime TimeStamp { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Command()
        {
            TimeStamp = DateTime.UtcNow;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
