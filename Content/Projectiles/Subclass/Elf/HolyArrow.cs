using System;
using Microsoft.Xna.Framework;
using Terraria;
using Trinitarian.Content.Buffs.Damage;
using Terraria.ModLoader;
using Trinitarian.Common;

namespace Trinitarian.Content.Projectiles.Subclass.Elf
{
	public class HolyArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Holy Arrow");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.arrow = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 180;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (TrinitarianLists.unholyEnemies.Contains(target.type))
            {
				target.AddBuff(ModContent.BuffType<Stunned>(), 12);
			}

            target.AddBuff(ModContent.BuffType<HolySmite>(), 120);
		}
    }
}