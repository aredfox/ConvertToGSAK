using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFileToStringConverter 
        : IGsakFileConverter<string>
    {
        private readonly string[] _columns = {
            "Code", "Waypoint Name", "Latitude", "Longitude"
        };

        private string GenerateHeader()
            => String.Join(",", _columns.Select(c => $"\"{c}\""));

        public Task<string> Convert(GsakFile gsakFile)
            => Task.FromResult(GenerateHeader());
    }
}
