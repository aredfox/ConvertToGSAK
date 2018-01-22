using System;
using System.Runtime.CompilerServices;
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

            var reducingString = input.Content.Replace("  ", " ");
            var code = TryExtractCode(reducingString);
            reducingString = ReduceString(reducingString, code);
            var longitude = TryExtractLongitude(reducingString);
            reducingString = ReduceString(reducingString, longitude);
            var latitude = TryExtractLatitude(reducingString);
            reducingString = ReduceString(reducingString, latitude);
            var waypointName = TryExtractWaypointName(reducingString);

            return Task.FromResult(new GsakFileLine {
                Code = code,
                WaypointName = waypointName,
                Latitude = latitude,
                Longitude = longitude
            });
        }

        private static string ReduceString(string reducingString, string reduceWith)
            => String.IsNullOrWhiteSpace(reduceWith)
                ? reducingString
                : reducingString?.Replace(reduceWith, "")?.Trim() ?? String.Empty;
        

        private string TryExtractCode(string reducingString)
        {
            try
            {                
                return reducingString.StartsWith("GC")
                    ? reducingString.Substring(0, 7)
                    : String.Empty;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        private string TryExtractWaypointName(string reducingString)
            => reducingString?.Trim() ?? String.Empty;

        private string TryExtractLongitude(string reducingString, bool hasLongitude = false) {
            try {                
                var lastIndex = reducingString.LastIndexOf("°", StringComparison.Ordinal);
                if(lastIndex < 0) return String.Empty;

                if (!hasLongitude) {
                    if (reducingString.IndexOf("°", StringComparison.Ordinal) == lastIndex)
                        return String.Empty;
                }

                var firstPart = reducingString
                    .Substring(0, lastIndex);                
                var indexOfLastSpaceInFirstPart = firstPart.LastIndexOf(" ", StringComparison.Ordinal);
                firstPart = firstPart.Substring(indexOfLastSpaceInFirstPart).Trim();

                var secondPart = reducingString
                    .Substring(lastIndex, reducingString.Length - lastIndex);

                return $"{firstPart}{secondPart}";
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        private string TryExtractLatitude(string reducingString)
            => TryExtractLongitude(reducingString, hasLongitude: true);
    }
}
