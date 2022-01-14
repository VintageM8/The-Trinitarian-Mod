using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class CryonicLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryonic Launcher");
        }

        public override void SetDefaults()
        {
            item.damage = 130;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 7;
            item.useAnimation = 12;
            item.reuseDelay = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = ProjectileID.RocketII;
            item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ItemID.GrenadeLauncher, 3);
            recipe.AddIngredient(ModContent.ItemType<EnchantedIceBall>(), 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}