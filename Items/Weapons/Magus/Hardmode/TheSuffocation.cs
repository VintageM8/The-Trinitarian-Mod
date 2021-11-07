using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Projectiles;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class TheSuffocation : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Suffocation");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 59;
            item.crit = 8;
            item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 13;
            item.useTime = 13;
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.rare = ItemRarityID.Yellow;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = false;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Suffocationproj>();
            item.shootSpeed = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
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