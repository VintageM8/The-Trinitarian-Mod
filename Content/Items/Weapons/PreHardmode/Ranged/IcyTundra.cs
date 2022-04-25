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
            item.damage = 19;
            item.ranged = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.SnowBallFriendly;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Snowball;
        }
    }
}