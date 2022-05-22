using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.VikingBow;
using Trinitarian.Content.Projectiles;
using Terraria.Audio;
using Terraria.ID;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe
{
    public class VikingAxeProj : HeldSword
    {
        public override string Texture => "Trinitarian/Content/Items/Weapons/Hardmode/Melee/VikingAxe/ZolzarAxe";

        public override void SetDefaults()
        {
            SwingTime = 30;
            holdOffset = 50f;
            base.SetDefaults();
            Projectile.width = Projectile.height = 92;
            Projectile.friendly = true;
            Projectile.localNPCHitCooldown = SwingTime;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.Melee;
        }

        public override float Lerp(float val)
        {
            return val == 1f ? 1f : (val == 0f
                ? 0f
                : (float)Math.Pow(2, val * 10f - 10f) / 2f);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit42, target.Center);

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                float distance = Vector2.Distance(Projectile.Center, Main.player[i].Center);
                if (distance <= 1050)
                {
                    Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 1;
                }
            }

            Projectile.NewProjectile(Projectile.GetSource_OnHit(target), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<BowAxe>(), Projectile.ai[0] == 0 ? 120 : 20, 2, Projectile.owner);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            // draws the slash
            Player player = Main.player[Projectile.owner];
            Texture2D slash = ModContent.Request<Texture2D>("Trinitarian/Assets/Textures/slash_01").Value;
            float mult = Lerp(Utils.GetLerpValue(0f, SwingTime, Projectile.timeLeft));
            float alpha = (float)Math.Sin(mult * Math.PI);
            Vector2 pos = player.Center + Projectile.velocity * (40f - mult * 30f);
            Main.EntitySpriteDraw(slash, pos - Main.screenPosition, null, Color.Silver * alpha, Projectile.velocity.ToRotation() - MathHelper.PiOver2, slash.Size() / 2, Projectile.scale / 2, SpriteEffects.None, 0);
            // draws the main blade
            Texture2D texture = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            Vector2 orig = texture.Size() / 2;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, orig, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}