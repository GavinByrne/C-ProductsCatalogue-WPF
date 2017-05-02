using DevExpress.Mvvm.DataModel;
using ProductsApplication.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApplication.ProductEntitiesDataModel {

    /// <summary>
    /// IProductEntitiesUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IProductEntitiesUnitOfWork : IUnitOfWork {
        
        /// <summary>
        /// The Product entities repository.
        /// </summary>
		IRepository<Product, int> Products { get; }
    }
}
