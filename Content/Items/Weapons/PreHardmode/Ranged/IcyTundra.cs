using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class IcyTundra : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Tundra");
        }

        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.SnowBallFriendly;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Snowball;
        }
    }
}