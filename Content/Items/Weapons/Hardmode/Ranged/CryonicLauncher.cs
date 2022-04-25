using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged
{
    public class CryonicLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryonic Launcher");
        }

        public override void SetDefaults()
        {
            Item.damage = 130;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 7;
            Item.useAnimation = 12;
            Item.reuseDelay = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 25, 0, 0);
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.RocketII;
            Item.shootSpeed = 9f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.MythrilAnvil)
                .AddIngredient(ItemID.GrenadeLauncher, 3)
                .AddIngredient(ModContent.ItemType<EnchantedIceBall>(), 2)
                .Register();
        }
    }
}