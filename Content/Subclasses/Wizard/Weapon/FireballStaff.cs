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
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Blue;
            item.mana = 5;
            item.UseSound = SoundID.Item21;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 15;
            item.channel = true;
            item.autoReuse = true;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 50;
            item.height = 56;
            item.shoot = ModContent.ProjectileType<FireStaffProj>();
            item.shootSpeed = 8f;
            item.knockBack = 3f;
            item.magic = true;
            item.value = Item.sellPrice(gold: 1, silver: 75);
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