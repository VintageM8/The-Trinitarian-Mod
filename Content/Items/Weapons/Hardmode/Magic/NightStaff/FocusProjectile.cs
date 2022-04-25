using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Magic.NightStaff;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.NightStaff
{
    public class FocusProjectile : ModProjectile
    {
        private float projectileRadius = 100;
        public override bool CanDamage() => false;
        public override string Texture => "Terraria/Projectile_" + ProjectileID.LostSoulFriendly;

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 30;
            Projectile.height = 38;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200000;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.ai[1]++;

            #region Active
            // Internal counters and damage modification

            if (player.dead || !player.active)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.timeLeft = 2;
            }

            Projectile.Center = Main.MouseWorld;

            if (Main.player[Projectile.owner].channel && Main.player[Projectile.owner].HeldItem.type == ModContent.ItemType<NightStaff>())
            {
                if (Projectile.ai[0] <= 850)
                {
                    Projectile.ai[0]++;

                    if (projectileRadius > 15)
                    {
                        if (Projectile.ai[0] % 10 == 0)
                        {
                            projectileRadius--;
                        }

                        // Should set to initial projectile damage instead of static for class damage scaling
                        Projectile.damage = (int)MathHelper.Lerp(2, 60, Projectile.ai[0] / 850f);
                    }
                }
                else
                {
                    Projectile.damage = 60;
                    projectileRadius = 15;
                }
            }
            else
            {
                Projectile.Kill();
            }
            #endregion

            #region Aura 
            // Dust code for the aura
            Vector2 origin = Projectile.Center;
            float radius = projectileRadius;
            int numLocations = 30;
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, 20f).RotatedBy(MathHelper.ToRadians(360f / numLocations * i));
                int dust = Dust.NewDust(position, 2, 2, 52, dustvelocity.X, dustvelocity.Y, 0, default, 1.5f);
                Main.dust[dust].noGravity = true;
            }
            #endregion

            #region Effect
            // Do stuff against enemy NPCs
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                // Make it so it doesn't affect friendly NPCs
                if (!Main.npc[i].friendly && Main.npc[i].active)
                {
                    float distance = Vector2.Distance(Projectile.Center, Main.npc[i].Center);
                    if (distance <= projectileRadius)
                    {
                        if (Projectile.ai[1] % (int)MathHelper.Lerp(10, 2, Projectile.ai[0] / 850) == 0)
                        {
                            Main.npc[i].StrikeNPC(Projectile.damage, 0f, 0);
                        }
                    }
                }
            }

            // Do stuff against friendly players
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (Main.player[i].active)
                {
                    float distance = Vector2.Distance(Projectile.Center, Main.player[i].Center);
                    if (distance <= projectileRadius)
                    {
                        if (Projectile.ai[1] % (int)MathHelper.Lerp(50, 10, Projectile.ai[0] / 850) == 0)
                        {
                            Main.player[i].HealEffect(Projectile.ai[0] < 850 ? (int)MathHelper.Lerp(1, 5, Projectile.ai[0] / 850) : 5);
                            Main.player[i].statLife += Projectile.ai[0] < 850 ? (int)MathHelper.Lerp(1, 5, Projectile.ai[0] / 850) : 5;
                        }
                    }
                }
            }
            #endregion
        }
    }
}
