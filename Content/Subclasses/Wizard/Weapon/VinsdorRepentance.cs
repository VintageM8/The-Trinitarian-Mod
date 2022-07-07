using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using ReLogic.Content;
using Terraria.GameContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class VinsdorRepentance : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vinsdor's Repentance");
            Tooltip.SetDefault("Shoots spikes out from the ground.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 56;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 15;

            Item.width = 48;
            Item.height = 48;

            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 5;
            Item.UseSound = SoundID.Item21;

            Item.noMelee = true;
            Item.knockBack = 4f;

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Pink;

            Item.autoReuse = true;

            Item.shoot = ProjectileType<VinsdorProj>();
            Item.shootSpeed = 8f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 6; i++)
            {
                position = Main.MouseWorld;

                float angle = Main.rand.NextFloat(MathHelper.PiOver2) + MathHelper.PiOver4;
                Vector2 unit = new Vector2(16, 0).RotatedBy(angle);
                for (int tries = 0; tries < 64; tries++)
                {
                    position += unit;
                    if (!Collision.CanHitLine(Main.MouseWorld, 1, 1, position, 1, 1))
                    {
                        break;
                    }
                }

                Vector2 shootSpeed = -new Vector2(unit.X / 6, unit.Y).SafeNormalize(Vector2.Zero) * velocity.Length();

                Projectile.NewProjectile(source, position, shootSpeed, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}