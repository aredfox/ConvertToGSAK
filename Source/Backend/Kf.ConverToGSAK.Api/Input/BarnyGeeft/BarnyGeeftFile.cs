using System.Collections.Generic;
using System.Threading.Tasks;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarnyGeeftFile
    {
        private readonly IConvertToGsakFile<BarnyGeeftFile> _toGsakFileConverter;

        public BarnyGeeftFile(IConvertToGsakFile<BarnyGeeftFile> toGsakFileConverter)
            => _toGsakFileConverter = toGsakFileConverter;        

        public IEnumerable<BarnyGeeftFileLine> Lines { get; set; }

        public async Task<GsakFile> Convert()
            => await _toGsakFileConverter.Convert(this);
    }
}
