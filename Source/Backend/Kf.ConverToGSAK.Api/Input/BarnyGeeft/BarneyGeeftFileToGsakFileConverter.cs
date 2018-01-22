using System.Linq;
using System.Threading.Tasks;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarneyGeeftFileToGsakFileConverter
        : IConvertToGsakFile<BarnyGeeftFile>
    {
        public Task<GsakFile> Convert(BarnyGeeftFile input) {
            if (input == null)
                return Task.FromResult(new GsakFile());

            if(input.Lines == null || input.Lines.Count() == 0)
                return Task.FromResult(new GsakFile());

            return Task.FromResult(new GsakFile());
        }
    }
}
