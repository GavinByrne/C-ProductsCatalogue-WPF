using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.WCF;
using ProductsApplication.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsApplication.ProductEntitiesDataModel {

    /// <summary>
    /// A ProductEntitiesUnitOfWork instance that represents the run-time implementation of the IProductEntitiesUnitOfWork interface.
    /// </summary>
    public class ProductEntitiesUnitOfWork : DbUnitOfWork<ProductEntities>, IProductEntitiesUnitOfWork {

        public ProductEntitiesUnitOfWork(Func<ProductEntities> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Product, int> IProductEntitiesUnitOfWork.Products {
            get { return GetRepository(x => x.Products, (Product x) => x.ProductId); }
        }
    }
}
