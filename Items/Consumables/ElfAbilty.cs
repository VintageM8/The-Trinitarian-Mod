using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian;
using Microsoft.Xna.Framework;
namespace Trinitarian.Items.Consumables
    {
    public class ElfItem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.rare = ItemRarityID.Red;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.maxStack = 1;
            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;
        }
        public override bool UseItem(Player player)
        {

            TrinitarianPlayer p = player.GetModPlayer<TrinitarianPlayer>();
            if (p.CurrentA == TrinitarianPlayer.AbiltyID.Elf)
            {
                return false;
            }
            else
            {
                CombatText.NewText(new Rectangle((int)player.Center.X, (int)player.Center.Y, 50, 50),new Color (0,200,0),"You Abilty is now Elf");
                p.CurrentA = TrinitarianPlayer.AbiltyID.Elf;
                return true;
            }
        }
    }
}
