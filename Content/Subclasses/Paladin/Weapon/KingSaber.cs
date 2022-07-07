using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Paladin;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KingSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King's Saber");
            Tooltip.SetDefault("Launches blobs of holy energy");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.noMelee = true;
            Item.damage = 92;
            Item.crit = 4;
            Item.knockBack = 0.5f;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ProjectileType<KingSabreProj>();
            Item.shootSpeed = 11;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int k = 0; k < 8; k++)
            {
                int i = Projectile.NewProjectile(source, player.Center + new Vector2(0, -32), velocity.RotatedByRandom(0.25f) * ((k + 3) * 0.08f), type, damage, knockback, player.whoAmI);
                Main.projectile[i].scale = Main.rand.NextFloat(0.4f, 0.9f);
            }
            return false;
        }
    }
}