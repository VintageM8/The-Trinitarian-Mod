using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.CoralGun
{
    public class PirateCove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pirate's Cove");
            Tooltip.SetDefault("Spews out sea foilage\nInflicts Drowning");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 48;
            Item.height = 30;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SeaFoilTwo>();
            Item.shootSpeed = 16f;
        }
    }
}
