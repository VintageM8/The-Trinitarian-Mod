using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee
{
    public class ZolzarAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar's Infuser");
            Tooltip.SetDefault("You shall fall like all foes before you.");
        }

        public override void SetDefaults()
        {
            item.damage = 278;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noUseGraphic = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<TheInfuser>();
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<UlvkilSoul>(), 3);
            recipe.AddIngredient(ItemType<StormEnergy>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}