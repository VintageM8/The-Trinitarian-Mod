using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian;

namespace Trinitarian
{
    class TrinitarianGlobalProjectile : GlobalProjectile
    {
        public bool Cloned = false;
        public override bool InstancePerEntity => true;
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            TrinitarianGlobalProjectile globalprojectile = projectile.GetGlobalProjectile<TrinitarianGlobalProjectile>();
            Projectile Mirror = Main.projectile[0];
            bool isClose = false;
            for (int i = 0; i < Main.projectile.Length; i++)
            {
                if (Main.projectile[i].type == ModContent.ProjectileType<ElfAbilityMirror>())
                {
                    Mirror = Main.projectile[i];
                }
            }
            if (Mirror.type == ModContent.ProjectileType<ElfAbilityMirror>())
            {
                for (int i = -5; i < 6; i++)
                {
                    int timer = (int)Mirror.ai[0];
                    Vector2 target = projectile.Center + new Vector2(-10 * i * (float)Math.Sin((2 * Math.PI) / 360 * timer), 10 * i * (float)Math.Cos((2 * Math.PI) / 360 * timer));
                    if ((target - Mirror.Center).LengthSquared() < 20 * 20)
                    {
                        isClose = true;
                    }
                }
                if (isClose && globalprojectile.Cloned == false)
                {
                    Projectile temp = Projectile.NewProjectileDirect(projectile.position, projectile.velocity.RotatedBy(Math.PI / 12), projectile.type, 1, 1, player.whoAmI, 0, 0);
                    projectile.velocity.RotatedBy(-Math.PI / 12);
                    TrinitarianGlobalProjectile globalprojectileClone = temp.GetGlobalProjectile<TrinitarianGlobalProjectile>();
                    globalprojectileClone.Cloned = true;
                    globalprojectile.Cloned = true;
                }
            }
        }
        //public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Texture2D texture = ModContent.GetTexture("Trinitarian/Projectiles/Mage/Test");
        //    Projectile Mirror = Main.projectile[0];
        //    Color c = new Color(0, 200, 0);
        //    for (int i = 0; i < Main.projectile.Length; i++)
        //    {
        //        if (Main.projectile[i].type == ModContent.ProjectileType<ElfAbilityMirror>())
        //        {
        //            Mirror = Main.projectile[i];
        //        }
        //    }
        //    for (int i = -5; i < 6; i++)
        //    {
        //        int timer = (int)Mirror.ai[0];
        //        Vector2 target = projectile.Center + new Vector2(-20 * i * (float)Math.Sin((2 * Math.PI) / 360 * timer), 20 * i * (float)Math.Cos((2 * Math.PI) / 360 * timer));
        //        spriteBatch.Draw(texture, target - Main.screenPosition, c);
        //    }            
        //    return true;
        //}
    }
}
