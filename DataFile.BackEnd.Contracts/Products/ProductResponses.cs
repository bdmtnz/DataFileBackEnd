namespace DataFile.BackEnd.Contracts.Products
{
    public record ProductResponse(
        string Id,
        string Name,
        decimal Price,
        int Stock
    );
}
