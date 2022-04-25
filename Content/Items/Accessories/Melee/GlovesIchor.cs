using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Accessories.Melee
{
    public class GlovesIchor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gloves of Ichor");
            Tooltip.SetDefault("Melee attacks deal ichor");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 52;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(76, 1, true);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 5);
            recipe.AddIngredient(ItemID.Ichor, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}