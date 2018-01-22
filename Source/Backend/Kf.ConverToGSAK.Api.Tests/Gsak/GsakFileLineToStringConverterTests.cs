using System;
using System.Collections.Generic;
using System.Linq;
using Kf.ConverToGSAK.Api.Gsak;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Gsak
{
    public sealed class GsakFileLineToStringConverterTests
    {
        [Fact]
        public async void An_empty_GSAK_file_line_outputs_an_empty_string()
        {
            var expected = String.Empty;
            var sut = new GsakFileLineToStringConverter();
            var actual = await sut.Convert(GsakTestHelper.EmptyGsakFileLine);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetValidGsakFileLines()
            => GsakTestHelper.ValidGsakFileLines.Select(gfl => new object[] {
                gfl,
                $"\"{gfl.Code}\",\"{gfl.WaypointName}\",\"{gfl.Latitude}\",\"{gfl.Longitude}\""
            })
        ;

        [Theory, MemberData(nameof(GetValidGsakFileLines))]
        public async void A_non_empty_file_line_outputs_a_correct_gsak_line(GsakFileLine gsakFileLine, string expected) {            
            var sut = new GsakFileLineToStringConverter();
            var actual = await sut.Convert(gsakFileLine);
            Assert.Equal(expected, actual);
        }
    }
}
