using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.AntiMagicBow;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.AntiMagicBow
{
    public class AntiMagicBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Anti-Magic Bow");
            Tooltip.SetDefault("Effective agianst Golem, Lunatic Cultist, and other magical foes.");
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item67;
            Item.crit = 4;
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 32;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Pink;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AntiMagicLaser>();
            Item.shootSpeed = 11f;
        }
    }
}