using System.Threading.Tasks;

namespace Kf.ConverToGSAK.Api.Common.Converters
{
    public interface IConverter<TInput, TOutput>
    {
        Task<TOutput> Convert(TInput input);
    }
}
