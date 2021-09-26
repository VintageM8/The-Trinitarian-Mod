using Terraria;
using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Accessories;
using Microsoft.Xna.Framework;

namespace Trinitarian
{
    public class TrinitarianGlobalNPC : GlobalNPC
    {
        // TODO: Does nothing, also doesn't work unless you set "InstancePerEntity".
        // public bool drowning;
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.ArmsDealer)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<GunParts>());
                nextSlot++;
            }

            if (type == NPCID.WitchDoctor)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Dartboard>());
                nextSlot++;
            }
        }
    }
}