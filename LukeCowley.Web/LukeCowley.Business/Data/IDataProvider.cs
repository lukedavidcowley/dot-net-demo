using System.Threading.Tasks;

namespace LukeCowley.Business.Data.Providers
{
    public interface IDataProvider
    {
        Task<string> GetData();
    }
}
