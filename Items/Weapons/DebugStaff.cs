using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;
using Trinitarian.Projectiles.VikingBoss;

namespace Trinitarian.Items.Weapons
{
    public class DebugStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Debug Staff");
            Tooltip.SetDefault("Helps test projectiles");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 52;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.CultistBossLightningOrbArc;
            item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            TrinitarianPlayer modplayer = player.GetModPlayer<TrinitarianPlayer>();
            Vector2 stuff = new Vector2(speedX, speedY);
            stuff.Normalize();
            stuff *= 7;
            Projectile.NewProjectile(position, stuff, ProjectileID.CultistBossLightningOrbArc, damage, knockBack, player.whoAmI, new Vector2(speedX, speedY).ToRotation(), 4);
            Projectile.NewProjectile(position, stuff * 4, ProjectileID.TerraBeam, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}