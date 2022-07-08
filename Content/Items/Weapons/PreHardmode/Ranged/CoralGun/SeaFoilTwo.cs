using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Trinitarian.Content.Buffs.Damage;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.CoralGun
{
    public class SeaFoilTwo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Sea Foilage");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 28;

            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.timeLeft = 200;

            Projectile.penetrate = 4;
        }

        public override bool PreAI()
        {
            if (Projectile.ai[0] == 0)
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            else
            {
                Projectile.ignoreWater = true;
                Projectile.tileCollide = false;
                int num996 = 15;
                bool flag52 = false;
                bool flag53 = false;
                Projectile.localAI[0] += 1f;
                if (Projectile.localAI[0] % 30f == 0f)
                    flag53 = true;

                int num997 = (int)Projectile.ai[1];
                if (Projectile.localAI[0] >= (float)(60 * num996))
                    flag52 = true;
                else if (num997 < 0 || num997 >= 200)
                    flag52 = true;
                else if (Main.npc[num997].active && !Main.npc[num997].dontTakeDamage)
                {
                    Projectile.Center = Main.npc[num997].Center - Projectile.velocity * 2f;
                    Projectile.gfxOffY = Main.npc[num997].gfxOffY;
                    if (flag53)
                    {
                        Main.npc[num997].HitEffect(0, 1.0);
                    }
                }
                else
                    flag52 = true;

                if (flag52)
                    Projectile.Kill();
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Drowning>(), 300);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.NPCHit42, Projectile.position);
            return true;
        }
    }
}
