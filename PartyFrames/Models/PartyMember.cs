using Dalamud.Game.ClientState.Resolvers;
using Lumina.Excel.GeneratedSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFrames.Models
{
    public class PartyMember
    {
        public int position { get; set; }
        public string name { get; set; } = string.Empty;
        public uint cHP { get; set; }
        public uint mHP { get; set; }
        public uint cMP { get; set; }
        public uint mMP { get; set; }
        public string world { get; set; } = string.Empty;
        public ExcelResolver<ClassJob> job { get; set; }

        public PartyMember(int position, string name, uint cHP, uint mHP, uint cMP, uint mMP, string world, ExcelResolver<ClassJob> job) {
            this.position = position;
            this.name = name;    
            this.cHP = cHP;
            this.mHP = mHP;
            this.cMP = cMP;
            this.mMP = mMP;
            this.world = world;
            this.job = job;
        }
    }
}
