﻿using CounterStrikeSharp.API;

namespace cs2_rockthevote
{
    public class PluginState : IPluginDependency<Plugin, Config>
    {
        public bool MapChangeScheduled { get; set; }
        public bool EofVoteHappening { get; set; }
        public bool ExtendTimeVoteHappening { get; set; }
        public bool CommandsDisabled { get; set; }
        public int ExtendsLeft { get; set; }

        public PluginState()
        {

        }

        public bool DisableCommands => MapChangeScheduled || EofVoteHappening || ExtendTimeVoteHappening || CommandsDisabled;

        public void OnMapStart(string map)
        {
            MapChangeScheduled = false;
            EofVoteHappening = false;
            ExtendTimeVoteHappening = false;
            CommandsDisabled = false;
            if (MapChangeScheduled || EofVoteHappening || ExtendTimeVoteHappening || CommandsDisabled)
            {
                Server.ExecuteCommand("css_plugins reload RockTheVote");
            }
        }
    }
}
