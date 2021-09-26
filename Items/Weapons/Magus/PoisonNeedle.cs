using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus
{
    public class PoisonNeedle : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Needle");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 15;
            item.crit = 0;
            item.damage = 18;
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 40;
            item.height = 36;
            item.maxStack = 999;
            item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.value = Item.sellPrice(silver: 75);
            item.shoot = ModContent.ProjectileType<PoisonNeedleproj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 5);
            recipe.AddIngredient(ItemID.Stinger, 3);
            recipe.AddIngredient(ItemType<Uranium>(), 8);
            recipe.AddIngredient(ItemType<PToken>(), 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 200);
            recipe.AddRecipe();
        }
    }
}