using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using ProductsApplication.Localization;using ProductsApplication.ProductEntitiesDataModel;

namespace ProductsApplication.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the ProductEntities data model.
    /// </summary>
    public partial class ProductEntitiesViewModel : DocumentsViewModel<ProductEntitiesModuleDescription, IProductEntitiesUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
		INavigationService NavigationService { get { return this.GetService<INavigationService>(); } }
	
        /// <summary>
        /// Creates a new instance of ProductEntitiesViewModel as a POCO view model.
        /// </summary>
        public static ProductEntitiesViewModel Create() {
            return ViewModelSource.Create(() => new ProductEntitiesViewModel());
        }

		        static ProductEntitiesViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<ProductEntitiesMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the ProductEntitiesViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProductEntitiesViewModel type without the POCO proxy factory.
        /// </summary>
        protected ProductEntitiesViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override ProductEntitiesModuleDescription[] CreateModules() {
			return new ProductEntitiesModuleDescription[] {
                new ProductEntitiesModuleDescription(ProductEntitiesResources.ProductPlural, "ProductCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Products)),
			};
        }
                		protected override void OnActiveModuleChanged(ProductEntitiesModuleDescription oldModule) {
            if(ActiveModule != null && NavigationService != null) {
                NavigationService.ClearNavigationHistory();
            }
            base.OnActiveModuleChanged(oldModule);
        }
	}

    public partial class ProductEntitiesModuleDescription : ModuleDescription<ProductEntitiesModuleDescription> {
        public ProductEntitiesModuleDescription(string title, string documentType, string group, Func<ProductEntitiesModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}