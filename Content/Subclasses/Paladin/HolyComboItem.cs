using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Subclasses.Paladin;
using Trinitarian.Content.Subclasses.Paladin.Weapon;
using System.Collections.Generic;

namespace Trinitarian.Content.Subclasses.Paladin
{
    public class HolyComboItem : GlobalItem
    {
        public override bool? UseItem(Item item, Terraria.Player player)
        {
            if (item.type == ModContent.ItemType<HolyBlade>())
            {
                if (player.GetModPlayer<HolyCombo>().combo % 7 == 0 && player.GetModPlayer<HolyCombo>().combo > 0)
                    player.AddBuff(BuffID.ShadowDodge, 300);
            }
            return true;
        }
    }
}