using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PowerRounds
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not to enable the plugin.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not to enable debugging.")]
        public bool Debug { get; set; } = false;

        [Description("How many rounds should pass before a power round.")]
        public int RoundsUnilPR { get; set; } = 5;
    }
}
