using System.Linq;
using Kf.ConverToGSAK.Api.Gsak;
using Kf.ConverToGSAK.Api.Input.BarnyGeeft;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Input.BarnyGeeft
{
    public class BarneyGeeftFileToGsakFileConverterTests
    {
        [Fact]
        public async void Can_parse_BarneyGeeft_to_Gsak() {
            var expectedGsakLines = 5;
            var expectedGsakString =
                "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"\r\n\"GC5001N\",\"Wer andern eine Grube gräbt ..\",\"N48° 03.327\",\"E7° 52.095\"\r\n\"GC5001P\",\"Wo ist das ? (Sissy T5) -RELOADED-\",\"N48° 06.990\",\"E7° 59.760\"\r\n\"GC5001R\",\"TB = GC\",\"N48° 05.459\",\"E7° 56.868\"\r\n\"GC5002H\",\"Wo ist die Kokosnuss?\",\"N50° 44.702\",\"E6° 54.268\"\r\n\"GC500AW\",\"Challenge-Wald II - 3x 1000 (Tradi/Multi/Mysterie)\",\"N52° 17.323\",\"E10° 46.621\"";

            var sut = new BarneyGeeftFileToGsakFileConverter(new BarneyGeeftFileLineToGsakFileLineConverter());
            var barneyGeeftFile = new BarnyGeeftFile(sut) {
                Lines = new [] {
                    new BarnyGeeftFileLine { RawContent = "GC5001N Wer andern eine Grube gräbt .. N48° 03.327 E7° 52.095" },
                    new BarnyGeeftFileLine { RawContent = "" },
                    new BarnyGeeftFileLine { RawContent = "GC5001P Wo ist das ?  (Sissy T5) -RELOADED- N48° 06.990 E7° 59.760" },
                    new BarnyGeeftFileLine { RawContent = "" },
                    new BarnyGeeftFileLine { RawContent = "GC5001R TB = GC N48° 05.459 E7° 56.868" },
                    new BarnyGeeftFileLine { RawContent = "" },
                    new BarnyGeeftFileLine { RawContent = "GC5002H Wo ist die Kokosnuss? N50° 44.702 E6° 54.268" },
                    new BarnyGeeftFileLine { RawContent = "" },
                    new BarnyGeeftFileLine { RawContent = "GC500AW Challenge-Wald II - 3x 1000 (Tradi/Multi/Mysterie) N52° 17.323 E10° 46.621" }
                }
            };

            var actualGsakFile = await barneyGeeftFile.Convert();
            var gsakFiletoStringConverter = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actualGstakString = await gsakFiletoStringConverter.Convert(actualGsakFile);

            Assert.Equal(expectedGsakLines, actualGsakFile.Lines.Count());
            Assert.Equal(expectedGsakString, actualGstakString);
        }
    }
}
