using System;
using System.Diagnostics.Metrics;
using System.Numerics;
using Dalamud.Data;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;
using ImGuiNET;
using ImGuiScene;
using Lumina.Excel.GeneratedSheets;
using PartyFrames.Models;

namespace SamplePlugin.Windows;

public class PartyFrame
{
    private Plugin plugin;
    private Vector2 barSize = new Vector2(160, 60);
    private Vector2 startPos = new Vector2(300, 375);
    public PartyFrame(Plugin plugin)
    {
        this.plugin = plugin;
    }

    public void Draw()
    {
        this.plugin.fillParty();
        var members = this.plugin.members;
        foreach (var member in members)
        {
            ImGui.SetNextWindowSize(barSize);
            ImGui.SetNextWindowPos(startPos);
            ImGui.Begin("Frame" + member.name, 
                ImGuiWindowFlags.NoTitleBar
                | ImGuiWindowFlags.NoScrollbar
                | ImGuiWindowFlags.NoMove
                | ImGuiWindowFlags.NoResize
            );
            ImDrawListPtr drawList = ImGui.GetWindowDrawList();
            drawList.AddRectFilled(new Vector2(barSize.X + startPos.X, barSize.Y + startPos.Y), barSize, ImGui.ColorConvertFloat4ToU32(Colors.JobColors[member.job.Id]));
            var icon = this.plugin.DataManager.GetImGuiTextureHqIcon(62000 + member.job.Id);
            ImGui.Image(icon.ImGuiHandle, new Vector2(16, 16));
            ImGui.SameLine();
            ImGui.Text(member.name);
            ImGui.End();
        }
    }
}
