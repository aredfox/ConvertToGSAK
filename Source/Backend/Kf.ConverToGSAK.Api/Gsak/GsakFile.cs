using System.Collections.Generic;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFile
    {
        public IEnumerable<GsakFileLine> Lines { get; set; }
    }
}
