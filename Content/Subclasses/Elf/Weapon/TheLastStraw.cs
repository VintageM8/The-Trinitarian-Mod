using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Elf;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class TheLastStraw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Last Straw");
            Tooltip.SetDefault("Shoots homing straw arrows\nEvery 8th hit a barrage of straws shoot out and explode on contact");
        }

        public override void SetDefaults()
        {
            Item.damage = 168;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = 5;
            Item.knockBack = 5;

            Item.rare = 7;
            Item.UseSound = SoundID.Item5;
            Item.width = 32;
            Item.height = 74;
            Item.shootSpeed = 4;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<StrawArrow>();
            Item.shootSpeed = 7f;
        }
    }
}