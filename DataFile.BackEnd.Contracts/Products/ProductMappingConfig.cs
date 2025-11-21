using DataFile.BackEnd.Domain.Products;
using Mapster;

namespace DataFile.BackEnd.Contracts.Products
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductResponse>()
                .Map(
                    dest => dest.Id,
                    src => src.Id.Value.ToString());
        }
    }
}
