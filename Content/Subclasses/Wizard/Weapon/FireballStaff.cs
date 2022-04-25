using Microsoft.Xna.Framework;
using System;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class FireballStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Staff");
            Tooltip.SetDefault("Playing with fire, deal with it.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Blue;
            Item.mana = 5;
            Item.UseSound = SoundID.Item21;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 15;
            Item.channel = true;
            Item.autoReuse = true;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.width = 50;
            Item.height = 56;
            Item.shoot = ModContent.ProjectileType<FireStaffProj>();
            Item.shootSpeed = 8f;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Magic;
            Item.value = Item.sellPrice(gold: 1, silver: 75);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 3; i++)
            {
                // The target for the projectile to move towards
                Vector2 target = Main.MouseWorld;
                position += Vector2.Normalize(new Vector2(speedX, speedY));
                float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
                Vector2 start = Vector2.UnitY.RotatedByRandom(6.32);
                Projectile.NewProjectile(position.X, position.Y, start.X * speed, start.Y * speed, type, damage, knockBack, player.whoAmI, target.X, target.Y);
            }

            return false;
        }
    }
}