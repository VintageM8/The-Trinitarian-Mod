using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic
{
    public class AngleFracture : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angel Fracture");
            Tooltip.SetDefault("A prehardmode Sky Fracture");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 42;
            Item.height = 40;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.SkyFracture;
            Item.shootSpeed = 18;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(-6);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.6f; // Watch out for dividing by 0 if there is only 1 projectile.

                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<StarSteel>(), 8)
                .AddIngredient(ItemID.Feather, 15)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
