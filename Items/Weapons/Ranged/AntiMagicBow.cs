using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Ranged;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class AntiMagicBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti-Magic Bow");
            Tooltip.SetDefault("Effective agianst Golem and Lunatic Cultist.");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item67;
            item.crit = 4;
            item.damage = 15;
            item.ranged = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<AntiMagicLaser>();
            item.shootSpeed = 11f;
        }
    }
}