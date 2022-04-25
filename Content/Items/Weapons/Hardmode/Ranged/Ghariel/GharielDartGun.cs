using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.Ghariel
{
    public class GharielDartGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghariel Dart Gun");
            Tooltip.SetDefault("Shoots darts.");
        }

        public override void SetDefaults()
        {
            Item.damage = 68;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 10;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Dart;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));//change to reduce spread
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
		
			return true;
		}

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.MythrilAnvil)
                .AddIngredient(ItemID.HallowedBar, 4)
                .AddIngredient(ItemID.DartRifle, 1)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Furnaces)
                .AddIngredient(ItemID.HallowedBar, 4)
                .AddIngredient(ItemID.DartPistol, 1)
                .Register();
        }
    }
}