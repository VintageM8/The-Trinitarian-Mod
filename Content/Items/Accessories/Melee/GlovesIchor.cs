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
            Item.width = 48;
            Item.height = 52;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(76, 1, true);
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<SteelBar>(), 5)
                .AddIngredient(ItemID.Ichor, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}