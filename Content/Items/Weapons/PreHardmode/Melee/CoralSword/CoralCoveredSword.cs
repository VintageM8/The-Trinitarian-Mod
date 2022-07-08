using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Damage;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.CoralSword
{
    public class CoralCoveredSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Covered Sword");
            Tooltip.SetDefault("After 4 consecutive strikes, sea foilage will be thrown at your enemy.\nInflicts Drowning\nYARRR!!");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Swing;
        }

        int charger;
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            charger++;
            if (charger >= 4)
            {
                SoundEngine.PlaySound(SoundID.Item14, target.position);
                Terraria.Projectile.NewProjectile(Item.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<Yarred>(), damage, knockBack, player.whoAmI);
                Terraria.Projectile.NewProjectile(Item.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<SeaFoilage>(), damage, knockBack, player.whoAmI);
                charger = 0;
            }

            target.AddBuff(ModContent.BuffType<Drowning>(), 300);
           
            
        }

        private void Yarr(Vector2 position)
        {

            for (int j = 0; j < 17; j++)
            {
                Vector2 direction = Main.rand.NextFloat(6.28f).ToRotationVector2();
                Dust.NewDustPerfect((position + (direction * 20) + new Vector2(0, 40)), ModContent.DustType<SolarDust>(), direction.RotatedBy(Main.rand.NextFloat(-0.2f, 0.2f) - 1.57f) * Main.rand.Next(2, 10), 0, new Color(255, 255, 60) * 0.8f, 1.6f);
            }
            Vector2 dir = -Vector2.UnitY.RotatedByRandom(0.3f) * 6;
            //Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, dir, ModContent.ProjectileType<Yarred>(), 0, 0, owner.whoAmI);
        }
    }
}

