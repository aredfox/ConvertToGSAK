using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Kf.ConverToGSAK.Api.Gsak;
using Kf.ConverToGSAK.Api.Input.BarnyGeeft;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Input.BarnyGeeft
{
    public sealed class BarneyGeeftIntegrationTests
    {
        [Fact]
        public async void Can_convert_to_gsak_formatted_file() {
            var expected = ReadFromResource("Kf.ConverToGSAK.Api.Tests.Input.BarnyGeeft.GC5-GSAK-formatted.txt");
            var expectedNumberOfBarneyGeeftLines = 47787;
            var expectedNumberOfGsakLines = 20193;
            var input = ReadFromResource("Kf.ConverToGSAK.Api.Tests.Input.BarnyGeeft.GC5-original.txt");

            var barneyGeeftFile = new BarnyGeeftFile(
                new BarneyGeeftFileToGsakFileConverter(new BarneyGeeftFileLineToGsakFileLineConverter()), 
                input
            );            

            var gsakFile = await barneyGeeftFile.Convert();
            var gsakToStringConverter = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actualGsakString = await gsakToStringConverter.Convert(gsakFile);

            Assert.Equal(actualGsakString, expected);
            Assert.Equal(expectedNumberOfBarneyGeeftLines, barneyGeeftFile.Lines.Count());
            Assert.Equal(expectedNumberOfGsakLines, gsakFile.Lines.Count());            
        }

        private string ReadFromResource(string resourceName) {
            using (var stream = Assembly
                .GetAssembly(typeof(BarneyGeeftIntegrationTests))
                .GetManifestResourceStream(resourceName)) {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8)) {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
