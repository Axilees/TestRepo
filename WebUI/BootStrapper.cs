using Model;
using Repository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ASPPatterns.Chap3.Layered.WebUI
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ProductRegistry>();
            });
        }
    }
    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            ForRequestedType<IProductRepository>()
            .TheDefaultIsConcreteType<MongoProductRepository>();
        }
    }
}