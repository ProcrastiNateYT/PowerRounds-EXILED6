using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;


namespace PowerRounds
{
    public class PowerRounds : Plugin<Config>
    {

        public override string Name => "Power Rounds";
        public override string Author => "ProcrastiNate";
        public override Version Version => new Version(0, 0, 1);
        public static PowerRounds Instance { get; } = new PowerRounds();

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        private List<RuleSet> _ruleSets = new List<RuleSet>();
        private Random _random = new Random();

        private Handlers.Player player;
        private Handlers.Server server;

        private int _roundCount = 0;

        private PowerRounds()
        {

        }

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
        }

        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnded;
        }

        private void OnRoundStarted()
        {
            _roundCount++;
        }

        private void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (_roundCount % PowerRounds.Instance.Config.RoundsUnilPR == 0)
            {

            }
        }

        public class RuleSet
        {

        }
    }
}
