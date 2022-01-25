using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Trinitarian.Subclasses.Elf.Weapon
{
    public class ElfBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf's Bow");
            Tooltip.SetDefault("Shoots 2 arrows for every 1\nAn Elf will give their life to protect the forest, we expect you to do the same.");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item67;
            item.crit = 4;
            item.damage = 15;
            item.ranged = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 65;
            item.useAnimation = 65;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Green;
            item.autoReuse = true;
            item.shoot = item.shoot = AmmoID.Arrow;
            item.shootSpeed = 11f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 2;
            float rotation = MathHelper.ToRadians(30);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2f;
                Projectile.NewProjectile(position.X + perturbedSpeed.X, position.Y + perturbedSpeed.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}