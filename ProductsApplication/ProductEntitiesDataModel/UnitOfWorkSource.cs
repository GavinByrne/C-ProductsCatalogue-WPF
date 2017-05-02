using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using DevExpress.Mvvm.DataModel.WCF;
using ProductsApplication.ProductService;
using System;
using System.Collections;
using System.Linq;

namespace ProductsApplication.ProductEntitiesDataModel {

    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        /// </summary>
        public static IUnitOfWorkFactory<IProductEntitiesUnitOfWork> GetUnitOfWorkFactory() {
            return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

		/// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<IProductEntitiesUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime) {
			if(isInDesignTime)
                return new DesignTimeUnitOfWorkFactory<IProductEntitiesUnitOfWork>(() => new ProductEntitiesDesignTimeUnitOfWork());
			Uri svcUri = new Uri("http://localhost:60996/ProductsWcfDataService.svc");
			return new DbUnitOfWorkFactory<IProductEntitiesUnitOfWork, ProductEntities>(
				() => new ProductEntitiesUnitOfWork(() => new ProductEntities(svcUri)),
				() => new ProductEntities(svcUri));
        }
    }
}