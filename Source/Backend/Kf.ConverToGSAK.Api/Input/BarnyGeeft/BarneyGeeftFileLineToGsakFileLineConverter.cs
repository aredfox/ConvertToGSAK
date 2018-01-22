using System;
using System.Threading.Tasks;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarneyGeeftFileLineToGsakFileLineConverter
        : IConvertToGsakFileLine<BarnyGeeftFileLine>
    {
        public Task<GsakFileLine> Convert(BarnyGeeftFileLine input) {
            if (input.IsEmpty)
                return Task.FromResult(GsakFileLine.EmptyGsakFileLine);            

            var code = TryExtractCode(input);
            var waypointName = TryExtractWaypointName(input);
            var latitude = TryExtractLatitude(input);
            var longitude = TryExtractLongitude(input);

            return Task.FromResult(new GsakFileLine {
                Code = code,
                WaypointName = waypointName,
                Latitude = latitude,
                Longitude = longitude
            });
        }        

        private string TryExtractCode(BarnyGeeftFileLine input)
        {
            try
            {                
                return input.Content.StartsWith("GC")
                    ? input.Content.Substring(0, 7)
                    : String.Empty;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        private string TryExtractWaypointName(BarnyGeeftFileLine input)
        {
            return "";
        }

        private string TryExtractLongitude(BarnyGeeftFileLine input) {
            try {                
                var lastIndex = input.Content.LastIndexOf("°", StringComparison.Ordinal);
                if (input.Content.IndexOf("°", StringComparison.Ordinal) == lastIndex)
                    return String.Empty;

                var firstPart = input.Content
                    .Substring(0, lastIndex);                
                var indexOfLastSpaceInFirstPart = firstPart.LastIndexOf(" ", StringComparison.Ordinal);
                firstPart = firstPart.Substring(indexOfLastSpaceInFirstPart).Trim();

                var secondPart = input.Content
                    .Substring(lastIndex, input.Content.Length - lastIndex);

                return $"{firstPart}{secondPart}";
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        private string TryExtractLatitude(BarnyGeeftFileLine input) {
            return "";
        }        
    }
}
