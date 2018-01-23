using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarnyGeeftFile
    {
        private readonly IConvertToGsakFile<BarnyGeeftFile> _toGsakFileConverter;        

        public BarnyGeeftFile(IConvertToGsakFile<BarnyGeeftFile> toGsakFileConverter, string input = null) {
            _toGsakFileConverter = toGsakFileConverter;

            if (input != null) {
                Lines = input.Split(new string[] {"\r\n", "\n"}, StringSplitOptions.None)
                    .Select(l => new BarnyGeeftFileLine {RawContent = l});
            }
        }

        public IEnumerable<BarnyGeeftFileLine> Lines { get; set; }

        public async Task<GsakFile> Convert()
            => await _toGsakFileConverter.Convert(this);
    }
}
