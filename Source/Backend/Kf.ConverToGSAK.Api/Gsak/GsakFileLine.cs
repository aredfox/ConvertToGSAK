using System;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFileLine
    {
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
