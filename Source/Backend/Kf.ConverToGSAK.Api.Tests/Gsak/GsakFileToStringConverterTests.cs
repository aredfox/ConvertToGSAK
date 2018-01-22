using System;
using System.Collections.Generic;
using System.Linq;
using Kf.ConverToGSAK.Api.Gsak;
using Xunit;

namespace Kf.ConverToGSAK.Api.Tests.Gsak
{
    public sealed class GsakFileToStringConverterTests
    {
        [Fact]
        public async void An_empty_GSAK_file_outputs_an_empty_string_with_headers_only() {
            var expected = "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"";
            var sut = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actual = await sut.Convert(GsakTestHelper.EmptyGsakFile);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void A_valid_GSAK_file_outputs_a_header_and_each_line_on_a_seperate_line() {
            var gsakFileLineToStringConverter = new GsakFileLineToStringConverter();
            var expectedHeader = "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"";
            var expectedBody = String.Join(
                    Environment.NewLine, 
                    String.Join(
                        Environment.NewLine, 
                        GsakTestHelper.ValidGsakFile
                            .Lines
                            .Select(async gfl => await gsakFileLineToStringConverter.Convert(gfl))
                            .Select(gflString => gflString.Result)
                    )
                );
            var expected = $"{expectedHeader}{Environment.NewLine}{expectedBody}";
            var sut = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actual = await sut.Convert(GsakTestHelper.ValidGsakFile);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void A_GSAK_file_containing_at_least_one_incomplete_input_outputs_a_header_and_each_line_on_a_seperate_line()
        {
            var gsakFileLineToStringConverter = new GsakFileLineToStringConverter();
            var expectedHeader = "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"";
            var expectedBody = String.Join(
                Environment.NewLine,
                String.Join(
                    Environment.NewLine,
                    GsakTestHelper.ValidGsakFile
                        .Lines.Concat(GsakTestHelper.InCompleteGsakFileLines)
                        .Where(gfl => !gfl.IsIncomplete())
                        .Select(async gfl => await gsakFileLineToStringConverter.Convert(gfl))
                        .Select(gflString => gflString.Result)
                )
            );
            var expected = $"{expectedHeader}{Environment.NewLine}{expectedBody}";
            var sut = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actual = await sut.Convert(GsakTestHelper.ValidGsakFile);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void A_GSAK_file_containing_at_least_one_empty_input_outputs_a_header_and_each_line_on_a_seperate_line()
        {
            var gsakFileLineToStringConverter = new GsakFileLineToStringConverter();
            var expectedHeader = "\"Code\",\"Waypoint Name\",\"Latitude\",\"Longitude\"";
            var expectedBody = String.Join(
                Environment.NewLine,
                String.Join(
                    Environment.NewLine,
                    GsakTestHelper.ValidGsakFile
                        .Lines.Concat(new List<GsakFileLine> { new GsakFileLine() })
                        .Where(gfl => !gfl.IsEmpty())
                        .Select(async gfl => await gsakFileLineToStringConverter.Convert(gfl))
                        .Select(gflString => gflString.Result)
                )
            );
            var expected = $"{expectedHeader}{Environment.NewLine}{expectedBody}";
            var sut = new GsakFileToStringConverter(new GsakFileLineToStringConverter());
            var actual = await sut.Convert(GsakTestHelper.ValidGsakFile);
            Assert.Equal(expected, actual);
        }
    }
}
