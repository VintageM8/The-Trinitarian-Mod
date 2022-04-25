using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Common.Projectiles
{
    public class ModAbilitys
    {
        public static void ElfAbility(Player player)
        {
            Projectile temp = Projectile.NewProjectileDirect(player.Center, Vector2.Zero, ModContent.ProjectileType<ElfAbilityMirror>(), 1, 1, player.whoAmI);
            TrinitarianGlobalProjectile globalprojectileClone = temp.GetGlobalProjectile<TrinitarianGlobalProjectile>();
            globalprojectileClone.Cloned = true;
        }
    }
    public class ElfAbilityMirror : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = false;
            Projectile.width = 30;
            Projectile.penetrate = 1;
            Projectile.height = 30;
            Projectile.friendly = false;
            Projectile.light = 1f;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.Center = player.Center + new Vector2(300 * (float)Math.Cos((2 * Math.PI) / 360 * Projectile.ai[0]), 300 * (float)Math.Sin((2 * Math.PI) / 360 * Projectile.ai[0]));
            Projectile.ai[0]++;
        }
    }
}

