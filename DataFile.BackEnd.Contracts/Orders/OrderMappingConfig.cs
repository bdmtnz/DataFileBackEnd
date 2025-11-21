using DataFile.BackEnd.Domain.Orders;
using Mapster;

namespace DataFile.BackEnd.Contracts.Orders
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderResponse>()
                .Map(
                    dest => dest.Id,
                    src => src.Id.Value.ToString())
                .Map(
                    dest => dest.UserId,
                    src => src.UserId.Value.ToString())
                .Map(
                    dest => dest.ProductId,
                    src => src.ProductId.Value.ToString());
        }
    }
}
