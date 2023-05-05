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
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public static PowerRounds Instance { get; } = new PowerRounds();

        private Handlers.Server serverHandler;
        private Handlers.Player playerHandler;

        public string[] prRounds = { "Lights Out" };
        public string _prName;

        private Random _random = new Random();

        private Handlers.Player player;
        private Handlers.Server server;

        private int _roundCount = 0;

        private PowerRounds()
        {

        }

        public override void OnEnabled()
        {
            Log.Debug("OnEnabled called.");

            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Log.Debug("OnDisabled called.");

            UnregisterEvents();
            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            Log.Debug("OnReloaded called.");

            base.OnReloaded();
        }

        private void RegisterEvents()
        {
            Log.Debug("RegisterEvents called.");

            serverHandler = new Handlers.Server();
            playerHandler = new Handlers.Player();
            
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
        }

        private void UnregisterEvents()
        {
            Log.Debug("UnregisterEvents called");
            
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnded;
            
            serverHandler = null;
            playerHandler = null;
        }

        private void OnRoundStarted()
        {
            _roundCount++;

            Log.Debug($"OnRoundStarted called. Current round:{_roundCount.ToString()}");

            if (_roundCount % PowerRounds.Instance.Config.RoundsUnilPR == 0)
            {
                Log.Debug("Round criteria met, choosing power round.");

                int rand = _random.Next(0, prRounds.Length - 1);

                _prName = prRounds[rand];

                Log.Debug($"There are {prRounds.Length} round types. Selected number {rand}.");

                Log.Info($"Power round chosen: {_prName}");

                switch (prRounds[rand])
                {
                    case "Juggernaut":
                        Rulesets.Juggernaut.prJuggernaut();
                        break;

                    case "Zombie Survival":
                        Rulesets.ZombieSurvival.prZombieSurvival();
                        break;

                    case "Lights Out":
                        Rulesets.LightsOut.prLightsOut();
                        break;


                }

            }
            else
            {
                Log.Debug("Round criteria not met, or something is wrong.");
            }
        }

        private void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Log.Debug("OnRoundEnded called");


        }
    }
}