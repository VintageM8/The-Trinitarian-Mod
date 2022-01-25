using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Subclasses.Paladin.Weapon
{
    public class HolySpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Spear");
        }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 28;
            item.useTime = 32;
            item.shootSpeed = 5f;
            item.knockBack = 10f;
            item.width = 64;
            item.height = 64;
            item.scale = 1f;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<HolySpearProj>();
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = false;
        }
    }
}
