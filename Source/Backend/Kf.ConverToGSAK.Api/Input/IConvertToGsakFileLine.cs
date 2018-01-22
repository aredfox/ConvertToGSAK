using Kf.ConverToGSAK.Api.Common.Converters;using Kf.ConverToGSAK.Api.Gsak;using Kf.ConverToGSAK.Api.Input.BarnyGeeft;namespace Kf.ConverToGSAK.Api.Input
{
    public interface IConvertToGsakFileLine<TInput> 
        : IConverter<TInput, GsakFileLine>
    {
    }
}
