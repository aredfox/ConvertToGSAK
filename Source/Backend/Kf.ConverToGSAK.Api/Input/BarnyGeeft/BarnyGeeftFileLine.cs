using System;

namespace Kf.ConverToGSAK.Api.Input.BarnyGeeft
{
    public sealed class BarnyGeeftFileLine
    {
        public string RawContent { get; set; }

        public string Content => RawContent?.Trim() ?? String.Empty;

        public bool IsEmpty
            => String.IsNullOrWhiteSpace(Content);
    }
}
