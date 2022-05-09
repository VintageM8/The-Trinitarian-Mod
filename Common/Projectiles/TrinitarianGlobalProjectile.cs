using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian;

namespace Trinitarian.Common.Projectiles
{
    class TrinitarianGlobalProjectile : GlobalProjectile
    {
        public bool Cloned = false;
        public override bool InstancePerEntity => true;


        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (NightBowArrows.Contains(projectile.whoAmI))
            {
                NightBowArrows.Remove(projectile.whoAmI);
            }                        
        }

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
                    Projectile temp = Projectile.NewProjectileDirect(projectile.GetSource_FromAI("global"), projectile.position, projectile.velocity.RotatedBy(Math.PI / 12), projectile.type, 1, 1, player.whoAmI, 0, 0);
                    projectile.velocity.RotatedBy(-Math.PI / 12);
                    TrinitarianGlobalProjectile globalprojectileClone = temp.GetGlobalProjectile<TrinitarianGlobalProjectile>();
                    globalprojectileClone.Cloned = true;
                    globalprojectile.Cloned = true;
                }
            }
        }

        /*public override bool? CanHitNPC(Projectile projectile, NPC target)
        {
            return target.immune[projectile.owner] <1;
        }*/
        //for nightsister bow
        //Speed of arrows.
        const int ArrowFireSpeed = 12;
        //Arrow spacing in circle
        const int ArrowSpacing = 20;

        const int CirlceSize = 90;
        public static List<int> NightBowArrows = new List<int>();
       
        public override bool PreAI(Projectile p)
        {
            if (NightBowArrows.Contains(p.whoAmI)) {
                int i = 0;
                for (int j = 0; j < NightBowArrows.Count; j++) {
                    if (NightBowArrows[j] == p.whoAmI)
                    {
                        i = j;
                        break;
                    }
                }
                if (!p.active)
                {
                    NightBowArrows.RemoveAt(i);
                }

                Player o = Main.player[p.owner];
                if (!o.channel)//o.channel
                {
                    Projectile PenR = new Projectile();
                    PenR.SetDefaults(p.type);
                    p.penetrate = PenR.penetrate;
                    PenR = null;
                    p.velocity = p.DirectionTo(Main.MouseWorld) * ArrowFireSpeed;
                    NightBowArrows.RemoveAt(i);
                }
                else
                {
                    p.penetrate = -1;
                    p.position = o.MountedCenter + new Vector2(CirlceSize).RotatedBy(MathHelper.ToRadians(i * ArrowSpacing));
                    if (Main.myPlayer == p.owner)
                    p.rotation = MathHelper.ToRadians(90) + p.DirectionTo(Main.MouseWorld).ToRotation();

                }

                
            }
            return !NightBowArrows.Contains(p.whoAmI);
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            int OldIm = target.immune[projectile.owner];
            target.immune[projectile.owner] = 20;
            if (!NightBowArrows.Contains(projectile.whoAmI))
            {
                target.immune[projectile.owner] = OldIm;
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
