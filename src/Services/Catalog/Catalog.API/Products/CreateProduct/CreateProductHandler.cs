using FluentValidation;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Parameter Name is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Parameter Description is required.");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Parameter ImageFile is required.");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Parameter Price should be greater than 0.");
    }
}
internal class CreateProductCommandHandler
    (IDocumentSession session, IValidator<CreateProductCommand> validator)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(command);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        session.Store(product);
        await session.SaveChangesAsync();

        return new CreateProductResult(product.Id);
    }
}
