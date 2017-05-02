using DevExpress.Mvvm.DataAnnotations;
using ProductsApplication.Localization;
using ProductsApplication.ProductService;

namespace ProductsApplication.ProductEntitiesDataModel {

    public class ProductEntitiesMetadataProvider {
		        public static void BuildMetadata(MetadataBuilder<Product> builder) {
			builder.DisplayName(ProductEntitiesResources.Product);
						builder.Property(x => x.ProductId).DisplayName(ProductEntitiesResources.Product_ProductId);
						builder.Property(x => x.Name).DisplayName(ProductEntitiesResources.Product_Name);
						builder.Property(x => x.Description).DisplayName(ProductEntitiesResources.Product_Description);
						builder.Property(x => x.Price).DisplayName(ProductEntitiesResources.Product_Price);
			        }
		    }
}