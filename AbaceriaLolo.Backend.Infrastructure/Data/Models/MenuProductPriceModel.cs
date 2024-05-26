
namespace AbaceriaLolo.Backend.Infrastructure.Data.Models
{
    public class MenuProductPriceModel
    {
        public int MenuProductPriceId { get; set; }
        public int MenuProductId { get; set; }
        public MenuProductModel? MenuProduct { get; set; }
        public int TypeOfServingId { get; set; }
        public TypeOfServingModel? TypeOfServing { get; set; }
        public decimal Price { get; set; }
    }
}
