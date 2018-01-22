using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kf.ConverToGSAK.Api.Gsak
{
    public sealed class GsakFileToStringConverter 
        : IGsakFileConverter<string>
    {
        private readonly IGsakFileLineConverter<string> _gsakFileLineConverter;

        private readonly string[] _columns = {
            "Code", "Waypoint Name", "Latitude", "Longitude"
        };

        public GsakFileToStringConverter(IGsakFileLineConverter<string> gsakFileLineConverter)
            => _gsakFileLineConverter = gsakFileLineConverter;        

        private string GenerateHeader()
            => String.Join(",", _columns.Select(c => $"\"{c}\""));

        public Task<string> Convert(GsakFile gsakFile) {            
            var header = GenerateHeader();

            if (gsakFile.Lines == null || gsakFile.Lines.Count(gfl => !gfl.IsEmpty() && !gfl.IsIncomplete()) == 0)
                return Task.FromResult(header);

            var body = GenerateBody(gsakFile);

            return Task.FromResult($"{header}{Environment.NewLine}{body}");
        }

        private string GenerateBody(GsakFile gsakFile) 
            => String.Join(
                Environment.NewLine,
                gsakFile
                    .Lines
                    .Select(async gfl => await _gsakFileLineConverter.Convert(gfl))
                    .Select(gflString => gflString.Result)
               )
        ;
        
    }
}
