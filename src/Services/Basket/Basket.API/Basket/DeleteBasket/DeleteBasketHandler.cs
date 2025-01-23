using FluentValidation;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IQuery<DeletBasketResult>;
public record DeletBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

internal class DeleteBasketCommandHandler : IQueryHandler<DeleteBasketCommand, DeletBasketResult>
{
    public async Task<DeletBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        return new DeletBasketResult(true);
    }
}
