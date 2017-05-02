using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using ProductsApplication.ProductEntitiesDataModel;
using ProductsApplication.Common;
using ProductsApplication.ProductService;

namespace ProductsApplication.ViewModels {

    /// <summary>
    /// Represents the single Product object view model.
    /// </summary>
    public partial class ProductViewModel : SingleObjectViewModel<Product, int, IProductEntitiesUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ProductViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ProductViewModel Create(IUnitOfWorkFactory<IProductEntitiesUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ProductViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ProductViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProductViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ProductViewModel(IUnitOfWorkFactory<IProductEntitiesUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Products, x => x.Name) {
                }



    }
}
