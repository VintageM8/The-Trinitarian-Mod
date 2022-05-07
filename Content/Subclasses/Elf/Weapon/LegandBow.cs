using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Projectiles.Subclass.Elf;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class LegandBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Legend's Bow");
            Tooltip.SetDefault("Created from a material gifted from the Paladins,\n" +
                "this bow is only a start to a holy journey\nStuns the unholy, inflicts Holy Smite on all mobs.");
            
        }

        public override void SetDefaults()
        {
            Item.damage = 44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 20;
            Item.height = 46;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.shoot = 3;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 1, 80, 0);
            Item.rare = 1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<HolyArrow>();
            Item.shootSpeed = 6.5f;
            Item.crit = 8;
        }
    }
}
