﻿using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Reflection;

namespace PowerRounds
{
    public class PowerRounds : Plugin<Config>
    {

        public override string Name => "Power Rounds";
        public override string Author => "ProcrastiNate";
        public override Version Version => new Version(0, 0, 1);
        public override Version RequiredExiledVersion => new Version(6, 0, 0);

        public static PowerRounds Instance { get; } = new PowerRounds();

        private string[] prRounds;
        private int prSelect;

        private Random _random = new Random();

        private Handlers.Player player;
        private Handlers.Server server;

        private int _roundCount = 0;


        /// <summary>
        /// Commented code below to be used in future implementation.
        /// </summary>
        //private string configPath = @"%appdata%\EXILED\Configs\PowerRounds";

        
        private PowerRounds()
        {

        }

        public override void OnEnabled()
        {
            RegisterEvents();
            
            
            /*
            string path = Environment.ExpandEnvironmentVariables(configPath);

            try
            {
                if (Directory.Exists(path))
                {
                    Log.Info("Directory already exists.");
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
                Log.Info("PowerRounds directory created.");

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            */

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
            
            
            if(_roundCount % PowerRounds.Instance.Config.RoundsUnilPR == 0)
            {
                int rand = _random.Next(0, prRounds.Length - 1);
                Log.Info($"Round chosen: {prRounds[rand]}");
            }
        }

        private void OnRoundEnded(RoundEndedEventArgs ev)
        {
            _roundCount++;
        }

        public class PowerRoundList
        {

        }
    }
}
