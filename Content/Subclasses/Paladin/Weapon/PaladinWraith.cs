using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Paladin;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class PaladinWraith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Paladin Wrath");
            Tooltip.SetDefault("After 6 consecutive strikes a holy bomb and a lightning strike will smite all foes.\nExtra damage is dealt to those deemed unholy by the greater powers/\n'The power of God is with you'");
        }


        public override void SetDefaults()
        {
            item.damage = 200;
            item.melee = true;
            item.width = 70;
            item.height = 76;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(1, 0, 0, 0);
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            //item.shoot = ModContent.ProjectileType<HolyFire>();
            item.shootSpeed = 4f;
            item.autoReuse = true;
        }

        int charger;
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
             charger++;
            if (charger >= 6)
            {
                Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 14);
                Terraria.Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<HolyBomb>(), damage, knockBack, player.whoAmI);
                Terraria.Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<LightningSpike>(), damage, knockBack, player.whoAmI);
                charger = 0;
            }
        }
    }
}
