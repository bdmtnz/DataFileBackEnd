namespace DataFile.BackEnd.Contracts.Orders
{
    public record OrderResponse(
        string Id,
        string UserId,
        string ProductId,
        int Quantity,
        decimal Total,
        DateTime CreatedOnUtc
    );
}
