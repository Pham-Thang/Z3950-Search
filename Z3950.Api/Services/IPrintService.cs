using System.Reflection;
using Z3950.Api.Attrs;

namespace Z3950.Api.Services
{
    public interface IPrintService
    {
        Dictionary<PropertyInfo, FieldNameAttribute> GetFields(Type type);
        bool Print<TEntity>(List<TEntity> data, string filePath);
    }
}
