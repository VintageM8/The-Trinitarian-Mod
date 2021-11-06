using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Ranged;

namespace Trinitarian.Subclasses.Elf
{
    public class ForestGreatbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Great bow");
            Tooltip.SetDefault("Fires a projectile that gives you a boost while you are in the forest.");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Blue;
            item.damage = 39;
            item.ranged = true;
            item.width = 48;
            item.height = 40;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.scale = 0.8f;
            item.noMelee = true;
            item.knockBack = 3f;
            item.UseSound = SoundID.Item17;
            item.shoot = ModContent.ProjectileType<ForestPower>();
            item.shootSpeed = 7f;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }
    }
}
