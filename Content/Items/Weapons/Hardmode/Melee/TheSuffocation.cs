using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Weapon.Melee;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee
{
    public class TheSuffocation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Suffocation");
        }

        public override void SetDefaults()
        {
            item.damage = 44;
            item.crit = 8;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 16;
            item.useTime = 16;
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.rare = ItemRarityID.Yellow;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Suffocationproj>();
            item.shootSpeed = 14;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlame, 5);
            recipe.AddIngredient(ItemID.WormTooth, 2);
            recipe.AddIngredient(ItemID.DemoniteBar, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}