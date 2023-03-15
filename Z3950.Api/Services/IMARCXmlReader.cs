using Zoom.Net;

namespace Z3950.Api.Services
{
    public interface IMARCXmlReader
    {
        List<TEntity> ReadMARCXmlStrings<TEntity>(List<string> marcxmls) where TEntity : class;
    }
}
