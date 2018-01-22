using System;
using System.Threading.Tasks;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFileLineToStringConverter
        : IGsakFileLineConverter<string>
    {
        public Task<string> Convert(GsakFileLine line)
            => Task.FromResult(ConvertToString(line))
        ;

        private string ConvertToString(GsakFileLine line) {
            if (line.IsEmpty()) return String.Empty;
            if (line.IsIncomplete()) return String.Empty;

            return $"\"{line.Code}\",\"{line.WaypointName}\",\"{line.Latitude}\",\"{line.Longitude}\"";
        }
    }
}
