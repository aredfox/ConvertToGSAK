using Kf.ConverToGSAK.Api.Common.Converters;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public interface IGsakFileLineConverter<TOutput>
        : IConverter<GsakFileLine, string>
    {
    }
}
