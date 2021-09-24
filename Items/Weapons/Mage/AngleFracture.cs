using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Mage
{
    public class AngleFracture : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angle Fracture");
            Tooltip.SetDefault("A prehardmode Sky Fracture");
            Item.staff[item.type] = true;
        }

         public override void SetDefaults()
        {
            item.damage = 17;
            item.magic = true;
            item.mana = 14;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.SkyFracture;
            item.shootSpeed = 19;
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StarSteel>(), 8);
            recipe.AddIngredient(ItemType<PToken>(), 2);
            recipe.AddIngredient(ItemID.Feather, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}