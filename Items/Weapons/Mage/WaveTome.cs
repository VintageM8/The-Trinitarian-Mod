﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Mage;

namespace Trinitarian.Items.Weapons.Mage
{
    public class WaveTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tidel Wave");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.magic = true;
            item.mana = 8;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 50, 60, 70);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<TidalWave>();
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}