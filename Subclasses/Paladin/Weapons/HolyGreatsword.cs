using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Subclasses.Paladin.Weapons
{
    public class HolyGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Greatsword");
            Tooltip.SetDefault("Creats a wave of holy energy");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 30;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(silver: 50);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.crit = 4;
            item.shoot = ModContent.ProjectileType<HolySlash>();
            item.shootSpeed = 9f;
        }
    }
}
