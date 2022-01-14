using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class TommyGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tommy Gun");
            Tooltip.SetDefault("23% Chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 78;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 35;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .23f;
        }
    }
}