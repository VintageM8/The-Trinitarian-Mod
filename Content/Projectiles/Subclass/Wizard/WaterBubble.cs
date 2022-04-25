using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Subclass.Wizard
{
    class WaterBubble : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Bubble");
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 2;
            Projectile.tileCollide = true;
            Projectile.light = 1f;
        }

        public override void AI() 
        {
            Main.dust[Dust.NewDust(Projectile.position,Projectile.width,Projectile.height,DustID.Electric,newColor:Color.LightBlue,Scale:1f)].noGravity = true;

            if (Main.player[Projectile.owner].channel)
            {
                Projectile.timeLeft = 2;
                Projectile.velocity = Main.MouseWorld-Projectile.Center;
                if (Projectile.velocity.Length() > 16) 
                {
                    Projectile.velocity.Normalize();
                    Projectile.velocity*=16;
                }
                Projectile.netUpdate = true;
            }

            //sound delay counts down automatically
            if (Projectile.soundDelay == 0) 
            {
			    SoundEngine.PlaySound(SoundID.Item93, Projectile.Center);
                Projectile.soundDelay = 20;
            }

            Projectile.frameCounter++;
            if (Projectile.frameCounter == 5)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 2;
            }

            Projectile.rotation += (float)Math.PI/2+0.1f;

            if (Main.rand.NextBool(10) && Main.myPlayer == Projectile.owner) 
            {
                //release projectile in random direction
                Main.projectile[Projectile.NewProjectile(Projectile.Center,new Vector2(4,0).RotatedByRandom(2*Math.PI),ProjectileType<BallLightningProjectile>(),Projectile.damage,Projectile.knockBack,Projectile.owner)].netUpdate = true;
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
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.Center);
            if (Main.myPlayer == Projectile.owner)
            {
                for (int i=0; i<10; i++) 
                {
                    //release projectile in random direction
                    Main.projectile[Projectile.NewProjectile(Projectile.Center,new Vector2(4,0).RotatedByRandom(2*Math.PI),ProjectileType<BallLightningProjectile>(),Projectile.damage,Projectile.knockBack,Projectile.owner)].netUpdate = true;
                }
            }
        }
    }
}