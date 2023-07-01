using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using SamplePlugin.Windows;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Party;
using Dalamud.Logging;
using Dalamud.Game.ClientState.Buddy;
using PMembers = PartyFrames.Models.PartyMember;
using System.Collections.Generic;
using System.Linq;
using ImGuiNET;
using Lumina.Excel.GeneratedSheets;
using Dalamud.Data;

namespace SamplePlugin
{
    public sealed class Plugin : IDalamudPlugin
    {
        public List<PMembers> members = new();
        public string Name => "Party Frames";
        private const string CommandName = "/pframes";

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        private ClientState clientState { get; init; }
        private PartyList partyList { get; init; }
        private BuddyList buddyList { get; init; }
        public DataManager DataManager { get; init; }
        public Configuration Configuration { get; init; }
        public WindowSystem WindowSystem = new("PartyFrames");

        private ConfigWindow ConfigWindow { get; init; }
        private PartyFrame PartyFrame { get; init; }

        public Plugin(
            DalamudPluginInterface pluginInterface,
            DataManager dataManager,
            CommandManager commandManager,
            ClientState clientState,
            PartyList partyList,
            BuddyList buddyList
            )
        {
            this.PluginInterface = pluginInterface; 
            this.DataManager = dataManager;
            this.CommandManager = commandManager;
            this.clientState = clientState;
            this.partyList = partyList;
            this.buddyList = buddyList;

            this.members = new List<PMembers>();


            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            ConfigWindow = new ConfigWindow(this);
            PartyFrame = new PartyFrame(this);

            WindowSystem.AddWindow(ConfigWindow);

            this.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Opens the partyframes config window"
            });

            this.PluginInterface.UiBuilder.Draw += DrawFrames;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;

            fillParty();
            PluginLog.Log(this.members.First().name);
        }

        public void fillParty()
        {
            //make list of elements
            //populate grid with elements
            //call update function whenever raid frame changes
            //specific updates for buffs/hp/etc? or maybe frame counter
            this.members = new List<PMembers>();

            var player = this.clientState.LocalPlayer;
            
            this.members.Add(
                new PMembers(
                    0,
                    player.Name.TextValue,
                    player.CurrentHp,
                    player.MaxHp,
                    player.CurrentMp,
                    player.MaxMp,
                    player.HomeWorld.ToString(),
                    player.ClassJob
                    )
                );

            if (partyList?.Length > 0)
            {
                foreach (var member in partyList!)
                {
                    this.members.Add(new PMembers(
                        0,
                        member.Name.TextValue,
                        member.CurrentHP,
                        member.MaxHP,
                        member.CurrentMP,
                        member.MaxMP,
                        member.World.ToString(),
                        member.ClassJob
                        )
                    );
                }
            }

            if (buddyList?.Length > 0)
            {
                foreach (var buddy in buddyList)
                {
                    PluginLog.Log(buddy.GameObject.Name.TextValue);
                    PluginLog.Log(buddy.GameObject.ObjectKind.ToString());
                }
            }
            else
            {
            }
        }

        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();
            
            ConfigWindow.Dispose();
            
            this.CommandManager.RemoveHandler(CommandName);
        }

        private void OnCommand(string command, string args)
        {
            // in response to the slash command, just display our main ui
        }

        private void DrawFrames()
        {
            PartyFrame.Draw();
        }

        public void DrawConfigUI()
        {
            ConfigWindow.IsOpen = true;
        }
    }
}
