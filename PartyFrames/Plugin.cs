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

namespace SamplePlugin
{
    public sealed class Plugin : IDalamudPlugin
    {
        public string Name => "Party Frames";
        private const string CommandName = "/pframes";
        private List<PMembers> members;

        private DalamudPluginInterface PluginInterface { get; init; }
        private CommandManager CommandManager { get; init; }
        public Configuration Configuration { get; init; }
        public WindowSystem WindowSystem = new("PartyFrames");

        private ConfigWindow ConfigWindow { get; init; }
        private MainWindow MainWindow { get; init; }

        public Plugin(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] CommandManager commandManager,
            [RequiredVersion("1.0")] ClientState clientState,
            [RequiredVersion("1.0")] PartyList partyList,
            [RequiredVersion("1.0")] BuddyList buddyList
            )
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            // you might normally want to embed resources and load them from the manifest stream
            var imagePath = Path.Combine(PluginInterface.AssemblyLocation.Directory?.FullName!, "goat.png");
            var goatImage = this.PluginInterface.UiBuilder.LoadImage(imagePath);

            ConfigWindow = new ConfigWindow(this);
            MainWindow = new MainWindow(this, goatImage);

            WindowSystem.AddWindow(ConfigWindow);
            WindowSystem.AddWindow(MainWindow);

            this.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Opens the partyframes config window"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;

            this.members = new List<PMembers>();
            //make list of elements
            //populate grid with elements
            //call update function whenever raid frame changes
            //specific updates for buffs/hp/etc? or maybe frame counter
            var player = clientState.LocalPlayer;
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
            } else
            {
            }
        }

        public void Dispose()
        {
            this.WindowSystem.RemoveAllWindows();
            
            ConfigWindow.Dispose();
            MainWindow.Dispose();
            
            this.CommandManager.RemoveHandler(CommandName);
        }

        private void OnCommand(string command, string args)
        {
            // in response to the slash command, just display our main ui
            MainWindow.IsOpen = true;
        }

        private void DrawUI()
        {
            this.WindowSystem.Draw();
        }

        public void DrawConfigUI()
        {
            ConfigWindow.IsOpen = true;
        }
    }
}
