using Kf.ConverToGSAK.Api.Gsak;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Gsak
{
    public sealed class GsakFileToStringConverterTests
    {
        [Fact]
        public async void An_empty_GSAK_file_outputs_an_empty_string_with_headers_only() {
            var expected = "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"";
            var sut = new GsakFileToStringConverter();
            var actual = await sut.Convert(GsakTestHelper.EmptyGsakFile);
            Assert.Equal(expected, actual);
        }
    }
}
