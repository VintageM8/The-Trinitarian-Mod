using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;


namespace Trinitarian.Items.Weapons.Mage
{
    public class MagicDrawStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draw Staff");
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
            item.shoot = ModContent.ProjectileType<DrawLaser>();
            item.shootSpeed = 10f;
            item.channel = true;
        }
        

    }
}