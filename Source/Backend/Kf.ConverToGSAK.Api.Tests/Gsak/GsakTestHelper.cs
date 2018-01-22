using System.Collections.Generic;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Tests.Gsak
{
    public static class GsakTestHelper
    {
        public static GsakFile EmptyGsakFile
            => new GsakFile();

        public static GsakFileLine EmptyGsakFileLine
            => new GsakFileLine();

        public static IEnumerable<GsakFileLine> ValidGsakFileLines
            => new [] {
                new GsakFileLine {
                    Code = "GC5001N",
                    WaypointName = "Wer andern eine Grube gräbt ..",
                    Latitude = "N48° 03.327",
                    Longitude = "E7° 52.095"
                },
                new GsakFileLine {                    
                    Code = "GC5029E",
                    WaypointName = "4 Bilder – 1 Wort reloaded #03",
                    Latitude = "N50° 36.479",
                    Longitude = "E8° 27.908"
                },
                new GsakFileLine {
                    Code = "GC5R11N",
                    WaypointName = "Culinair Restaurant \"Waterrijk\"",
                    Latitude = "N51° 26.460",
                    Longitude = "E5° 23.988"
                }
            };

        public static IEnumerable<GsakFileLine> InCompleteGsakFileLines
            => new[] {
                new GsakFileLine {
                    Code = "GC5001N",
                    WaypointName = "Wer andern eine Grube gräbt ..",
                    Latitude = "N48° 03.327"                    
                },                
            };

        public static GsakFile ValidGsakFile
            => new GsakFile {
                Lines = ValidGsakFileLines
            };
    }
}
