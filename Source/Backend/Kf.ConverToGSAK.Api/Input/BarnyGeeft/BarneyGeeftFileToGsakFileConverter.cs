using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kf.ConverToGSAK.Api.Gsak;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarneyGeeftFileToGsakFileConverter
        : IConvertToGsakFile<BarnyGeeftFile>
    {
        private readonly IConvertToGsakFileLine<BarnyGeeftFileLine> _barneyGeeftFileLineToGsakFileLineConverter;

        public BarneyGeeftFileToGsakFileConverter(
            IConvertToGsakFileLine<BarnyGeeftFileLine> barneyGeeftFileLineToGsakFileLineConverter
        ) => _barneyGeeftFileLineToGsakFileLineConverter = barneyGeeftFileLineToGsakFileLineConverter;        

        public async Task<GsakFile> Convert(BarnyGeeftFile input) {
            if (input == null)
                return await Task.FromResult(new GsakFile());

            if(input.Lines == null || input.Lines.Count(l => !l.IsEmpty) == 0)
                return await Task.FromResult(new GsakFile());

            var gsakLines = new List<GsakFileLine>();
            foreach (var line in input.Lines.Where(l => !l.IsEmpty)) {
                var gsakLine = await _barneyGeeftFileLineToGsakFileLineConverter.Convert(line);
                gsakLines.Add(gsakLine);
            }

            return await Task.FromResult(new GsakFile { Lines = gsakLines });
        }
    }
}
