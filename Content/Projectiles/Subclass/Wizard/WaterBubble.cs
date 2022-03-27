using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    class WaterBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Bubble");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.magic = true;
            projectile.timeLeft = 2;
            projectile.tileCollide = true;
            projectile.light = 1f;
        }

        public override void AI() 
        {
            Main.dust[Dust.NewDust(projectile.position,projectile.width,projectile.height,DustID.Electric,newColor:Color.LightBlue,Scale:1f)].noGravity = true;

            if (Main.player[projectile.owner].channel)
            {
                projectile.timeLeft = 2;
                projectile.velocity = Main.MouseWorld-projectile.Center;
                if (projectile.velocity.Length() > 16) 
                {
                    projectile.velocity.Normalize();
                    projectile.velocity*=16;
                }
                projectile.netUpdate = true;
            }

            //sound delay counts down automatically
            if (projectile.soundDelay == 0) 
            {
			    Main.PlaySound(SoundID.Item93, projectile.Center);
                projectile.soundDelay = 20;
            }

            projectile.frameCounter++;
            if (projectile.frameCounter == 5)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 2;
            }

            projectile.rotation += (float)Math.PI/2+0.1f;

            if (Main.rand.NextBool(10) && Main.myPlayer == projectile.owner) 
            {
                //release projectile in random direction
                Main.projectile[Projectile.NewProjectile(projectile.Center,new Vector2(4,0).RotatedByRandom(2*Math.PI),ProjectileType<BallLightningProjectile>(),projectile.damage,projectile.knockBack,projectile.owner)].netUpdate = true;
            }
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) 
        {
            width = 2;
            height = 2;
            return true;
        }

        public override void Kill(int timeLeft) 
        {
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.NPCDeath14, projectile.Center);
            if (Main.myPlayer == projectile.owner)
            {
                for (int i=0; i<10; i++) 
                {
                    //release projectile in random direction
                    Main.projectile[Projectile.NewProjectile(projectile.Center,new Vector2(4,0).RotatedByRandom(2*Math.PI),ProjectileType<BallLightningProjectile>(),projectile.damage,projectile.knockBack,projectile.owner)].netUpdate = true;
                }
            }
        }
    }
}