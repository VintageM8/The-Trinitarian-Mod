using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Trinitarian.Content.Projectiles.Weapon.Melee
{
    public class Suffocationproj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = false;
            Projectile.width = 24;
            Projectile.penetrate = -1;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 3;
        }
        int Suffocationtime = 0;
        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Main.dust[Dust.NewDust(Projectile.position,Projectile.width,Projectile.height,DustID.Blood,newColor:Color.Red,Scale:1f)].noGravity = true;
                Suffocationtime++;

                if (Suffocationtime == 8)
                {                   
                    Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center,new Vector2(4,0).RotatedByRandom(2*Math.PI),ProjectileID.CursedFlameFriendly,Projectile.damage,Projectile.knockBack,Projectile.owner)].netUpdate = true;
                    Suffocationtime = 0;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 300);
            target.AddBuff(BuffID.CursedInferno, 300);
            target.AddBuff(BuffID.Ichor, 300);
        }
    }
}
