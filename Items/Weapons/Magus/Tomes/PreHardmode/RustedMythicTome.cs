using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;
using Trinitarian.Items.Materials.Bars;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Magus.Tomes.PreHardmode
{
    public class RustedMythicTome : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Mythic Tome");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 15;
            item.width = 112;
            item.height = 40;
            item.useTime = 16;
            item.useAnimation = 16;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<RsutedTomeProj>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddIngredient(ModContent.ItemType<RustyMetal>(), 5);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}
