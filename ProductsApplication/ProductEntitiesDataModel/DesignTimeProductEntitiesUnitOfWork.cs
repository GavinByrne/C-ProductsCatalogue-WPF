using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using ProductsApplication.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApplication.ProductEntitiesDataModel {

    /// <summary>
    /// A ProductEntitiesDesignTimeUnitOfWork instance that represents the design-time implementation of the IProductEntitiesUnitOfWork interface.
    /// </summary>
    public class ProductEntitiesDesignTimeUnitOfWork : DesignTimeUnitOfWork, IProductEntitiesUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the ProductEntitiesDesignTimeUnitOfWork class.
        /// </summary>
        public ProductEntitiesDesignTimeUnitOfWork() {
        }

        IRepository<Product, int> IProductEntitiesUnitOfWork.Products {
            get { return GetRepository((Product x) => x.ProductId); }
        }
    }
}
