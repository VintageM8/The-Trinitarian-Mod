using System;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Trinitarian.Content.NPCs.Bosses.Zolzar
{
    public class VikingScreenShaderData : ScreenShaderData
    {
        private int VikingIndex;

        public VikingScreenShaderData(string passName)
            : base(passName)
        {
        }

        private void UpdateVikingIndex()
        {
            int VikingType = ModLoader.GetMod("Trinitarian").Find<ModNPC>("VikingBoss").Type;
            if (VikingIndex >= 0 && Main.npc[VikingIndex].active && Main.npc[VikingIndex].type == VikingType)
            {
                return;
            }
            VikingIndex = -1;
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == VikingType)
                {
                    VikingIndex = i;
                    break;
                }
            }
        }

        public override void Apply()
        {
            UpdateVikingIndex();
            if (VikingIndex != -1)
            {
                UseTargetPosition(Main.npc[VikingIndex].Center);
            }
            base.Apply();
        }
    }
}