

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, List<string> Category,  string ImageFile, decimal Price): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product from command object
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //save product to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return CreateProductResult
            return new CreateProductResult(product.Id);
        }
    }
}
