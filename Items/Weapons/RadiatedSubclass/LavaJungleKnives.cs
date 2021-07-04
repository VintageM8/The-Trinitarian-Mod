using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Projectiles.RadiatedSubclass;

namespace Trinitarian.Items.Weapons.RadiatedSubclass
{
    public class LavaJungleKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lava Dipped Jungle Knifes");
            Tooltip.SetDefault("Inficts OnFire! and Poisoned");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.width = 10;
            item.height = 24;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 45, 0);
            item.rare = ItemRarityID.Orange;
            item.maxStack = 999;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<LavaJungleKnivesproj>();
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.Stinger, 2);
            recipe.AddIngredient(ItemID.Hellstone, 2);
            recipe.AddIngredient(ItemID.ThrowingKnife, 50);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 2);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}