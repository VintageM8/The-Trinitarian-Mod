using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian;
using Microsoft.Xna.Framework;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Consumables.SubclassAbility
{
    public class ElfItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.maxStack = 1;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;
        }
        
        public override bool? UseItem(Player player)
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
