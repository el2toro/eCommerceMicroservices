namespace Ordering.Domain.Models;

// Rech domain model: having implementation
public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public Customer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Customer { Id = id, Name = name, Email = email };
    }
}
