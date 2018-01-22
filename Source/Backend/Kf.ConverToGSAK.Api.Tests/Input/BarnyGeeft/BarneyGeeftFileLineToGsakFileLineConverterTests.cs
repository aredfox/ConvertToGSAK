using Kf.ConverToGSAK.Api.Input.BarnyGeeft;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Input.BarnyGeeft
{
    public sealed class BarneyGeeftFileLineToGsakFileLineConverterTests
    {
        [Theory, 
         InlineData("GC5001P Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760  ", "GC5001P"),
         InlineData("Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760", ""),
         InlineData("  GC500DG Abakus N48° 29.862 E8° 50.068", "GC500DG"),
         InlineData("", "")]
        public async void Can_extract_code_from_string(string line, string expected) {
            var sut = new BarneyGeeftFileLineToGsakFileLineConverter();
            var actual = await sut.Convert(new BarnyGeeftFileLine { RawContent = line });
            Assert.Equal(expected, actual.Code);
        }

        [Theory,
         InlineData("GC5001P Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760  ", "E7° 59.760"),
         InlineData("Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760", "E7° 59.760"),
         InlineData("  GC500DG Abakus N48° 29.862 E8° 50.068", "E8° 50.068"),
         InlineData("  GC500DG Abakus N48° 29.862  ", ""),
         InlineData("", ""),
         InlineData("Moose's Challenge: The 100 Mile Challenge N40° 31.858 W105° 04.488", "W105° 04.488")]
        public async void Can_extract_longitude_from_string(string line, string expected)
        {
            var sut = new BarneyGeeftFileLineToGsakFileLineConverter();
            var actual = await sut.Convert(new BarnyGeeftFileLine { RawContent = line });
            Assert.Equal(expected, actual.Longitude);
        }

        [Theory,
         InlineData("GC5001P Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760  ", "N48° 06.990"),
         InlineData("Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760", "N48° 06.990"),
         InlineData("  GC500DG Abakus N48° 29.862 E8° 50.068", "N48° 29.862"),
         InlineData("  GC500DG Abakus N48° 29.862  ", "N48° 29.862"),
         InlineData("", ""),
         InlineData("Moose's Challenge: The 100 Mile Challenge N40° 31.858 W105° 04.488", "N40° 31.858")]
        public async void Can_extract_latitude_from_string(string line, string expected)
        {
            var sut = new BarneyGeeftFileLineToGsakFileLineConverter();
            var actual = await sut.Convert(new BarnyGeeftFileLine { RawContent = line });
            Assert.Equal(expected, actual.Latitude);
        }

        [Theory,
         InlineData("GC5001P Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760  ", "Wo ist das ? (Sissy T5) -RELOADED-"),
         InlineData("Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760", "Wo ist das ? (Sissy T5) -RELOADED-"),
         InlineData("  GC500DG Abakus N48° 29.862 E8° 50.068", "Abakus"),
         InlineData("  GC500DG Abakus N48° 29.862  ", "Abakus"),
         InlineData("", ""),
         InlineData("Moose's Challenge: The 100 Mile Challenge N40° 31.858 W105° 04.488", "Moose's Challenge: The 100 Mile Challenge")]
        public async void Can_extract_waypointname_from_string(string line, string expected)
        {
            var sut = new BarneyGeeftFileLineToGsakFileLineConverter();
            var actual = await sut.Convert(new BarnyGeeftFileLine { RawContent = line });
            Assert.Equal(expected, actual.WaypointName);
        }
    }
}
