using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class TheSoulEater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Soul Eater");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.noMelee = true;
            item.ranged = true;
            item.width = 16;
            item.height = 36;
            item.useTime = 15;
            item.useAnimation = 15;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 8, 50, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Projectiles.SoulEater>();
            item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.DemoniteBar, 22);
            recipe.AddIngredient(ItemID.ShadowScale, 25);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}