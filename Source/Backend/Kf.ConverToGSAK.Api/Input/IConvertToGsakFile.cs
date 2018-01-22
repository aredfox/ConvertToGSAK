using Kf.ConverToGSAK.Api.Common.Converters;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input
{
    public interface IConvertToGsakFile<TInput> : IConverter<TInput, GsakFile>
    {
    }
}
