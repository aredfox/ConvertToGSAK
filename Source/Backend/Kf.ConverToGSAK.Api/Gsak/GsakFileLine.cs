using System;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFileLine
    {
        public static GsakFileLine EmptyGsakFileLine
            => new GsakFileLine {
                Code = String.Empty,
                WaypointName = String.Empty,
                Latitude = String.Empty,
                Longitude = String.Empty
            }
        ;

        public string Code { get; set; }
        public string WaypointName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public bool IsEmpty()
            => String.IsNullOrWhiteSpace(Code)
               && String.IsNullOrWhiteSpace(WaypointName)
               && String.IsNullOrWhiteSpace(Latitude)
               && String.IsNullOrWhiteSpace(Longitude)
        ;

        public bool IsIncomplete()
            => String.IsNullOrWhiteSpace(Code)
               || String.IsNullOrWhiteSpace(WaypointName)
               || String.IsNullOrWhiteSpace(Latitude)
               || String.IsNullOrWhiteSpace(Longitude)
        ;
    }
}
