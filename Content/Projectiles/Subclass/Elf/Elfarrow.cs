using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Projectiles.Subclass.Elf
{
    public class Elfarrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf Arrow");
        }
        public bool stopped = false;
        public override void SetDefaults()
        {
            stopped = false;
            Projectile.width = 18;
            Projectile.height = 36;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 240;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            //aiType = 1;           
        }


        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<BiomeDust>(), Projectile.velocity.X * 0f, Projectile.velocity.Y * 0f);
            if (!stopped)
            {
                Projectile.velocity.X *= .92f;
                Projectile.velocity.Y *= .92f;
            }

            if (Math.Abs(Projectile.velocity.X) <= .2 && Math.Abs(Projectile.velocity.Y) <= .2)
            {
                if (!stopped)
                {
                    stopped = true;
                    Vector2 targetPos;
                    targetPos.X = Main.MouseWorld.X;
                    targetPos.Y = Main.MouseWorld.Y;
                    Projectile.velocity = Projectile.DirectionTo(targetPos) * 22f;
                }
            }
        }
    }
}