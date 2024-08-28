namespace CatalogAPI.Products.DeleteProduct
{
    //public record DeleteProductRequest();
    public record DeleteProductResponse(bool IsSuccess);    
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (ISender sender, Guid id) =>
            {
                var command = new DeleteProductCommand(id);
                var result = await sender.Send(command);
                var response = new DeleteProductResponse(result.IsSuccess);
                return Results.Ok(response);
            })
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete a Product");
        }

    }
}
