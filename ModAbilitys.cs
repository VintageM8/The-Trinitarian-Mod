using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian
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
            projectile.ignoreWater = false;
            projectile.width = 30;
            projectile.penetrate = 1;
            projectile.height = 30;
            projectile.friendly = false;
            projectile.light = 1f;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
            projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center + new Vector2(300 * (float)Math.Cos((2 * Math.PI) / 360 * projectile.ai[0]), 300 * (float)Math.Sin((2 * Math.PI) / 360 * projectile.ai[0]));
            projectile.ai[0]++;
        }
    }
}

