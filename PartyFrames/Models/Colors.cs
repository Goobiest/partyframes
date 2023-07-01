using Dalamud.Game.ClientState.JobGauge.Enums;
using Lumina.Excel.GeneratedSheets;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace PartyFrames.Models
{
    public static class Colors
    {
        public static readonly Dictionary<uint, Vector4> JobColors = new Dictionary<uint, Vector4> {
            { 0, new Vector4(0.5f,0.5f,0.5f,1f) },//adv
            { 1, new Vector4(130f/255f, 150f/255f, 145f/255f, 1f) },//gla
            { 2, new Vector4(173f/255f, 158f/255f, 72f/255f, 1f) },//pgl
            { 3, new Vector4(188f/255f, 115f/255f, 114f/255f, 1f) },//mrd
            { 4, new Vector4(80f/255f, 87f/255f, 160f/255f, 1f) },//lnc
            { 5, new Vector4(153f/255f, 169f/255f, 93f/255f, 1f) },//arc
            { 6, new Vector4(204f/255f, 201f/255f, 178f/255f, 1f) },//cnj
            { 7, new Vector4(67f/255f, 47f/255f, 95f/255f, 1f) },//thm
            { 8, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//crp
            { 9, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//bsm
            { 10, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//arm
            { 11, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//gsm
            { 12, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//ltw
            { 13, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//wvr
            { 14, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//alc
            { 15, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//cul
            { 16, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//min
            { 17, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//btn
            { 18, new Vector4(155f/255f, 155f/255f, 155f/255f, 1f) },//fsh
            { 19, new Vector4(178f/255f, 208f/255f, 201f/255f, 1f) },//pld
            { 20, new Vector4(203f/255f, 174f/255f, 3f/255f, 1f) },//mnk
            { 21, new Vector4(206f/255f, 80f/255f, 77f/255f, 1f) },//war
            { 22, new Vector4(56f/255f, 67f/255f, 194f/255f, 1f) },//drg
            { 23, new Vector4(163f/255f,188f/255f,68f/255f, 1f) },//brd
            { 24, new Vector4(255f/255f, 248f/255f, 202f/255f, 1f) },//whm
            { 25, new Vector4(49f/255f, 33f/255f, 70f/255f, 1f) },//blm
            { 26, new Vector4(195f/255f, 221f/255f, 145f/225f, 1f) },//acn
            { 27, new Vector4(172f/255f, 223f/255f, 72f/255f, 1f) },//smn
            { 28, new Vector4(74f/255f, 68f/255f, 164f/255f, 1f) },//sch
            { 29, new Vector4(175f/255f, 82f/255f, 100f/255f, 1f) },//rog
            { 30, new Vector4(182f/255f, 30f/255f, 60f/255f, 1f) },//nin
            { 31, new Vector4(158f/255f, 237f/255f, 226f/255f, 1f) },//mch
            { 32, new Vector4(82f/255f, 33f/255f, 37f/255f, 1f) },//drk
            { 33, new Vector4(162f/255f, 106f/255f, 24f/255f, 1f) },//ast
            { 34, new Vector4(85f/255f, 56f/255f, 28f/255f, 1f) },//sam
            { 35, new Vector4(154f/255f, 28f/255f, 46f/255f, 1f) },//rdm
            { 36, new Vector4(54f/255f, 95f/255f, 147f/255f, 1f) },//blu
            { 37, new Vector4(227f/255f, 208f/255f, 32f/255f, 1f) },//gnb
            { 38, new Vector4(239f/255f, 199f/255f, 165f/255f, 1f) },//dnc
            { 39, new Vector4(81f/255f, 80f/255f, 69f/255f, 1f) },//rpr
            { 40, new Vector4(198f/255f, 231f/255f, 242f/2255f, 1f) },//sge
        };
    }
}
