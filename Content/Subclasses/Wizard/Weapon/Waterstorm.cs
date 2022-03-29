using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Wizard;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class Waterstorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Waterstrom");
            Tooltip.SetDefault("Fires homing bubbles that pop into giant waternados.");
        }

        public override void SetDefaults()
        {
            item.damage = 80;
            item.ranged = true;
            item.width = 46;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 15;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<WaterstormBubble>();
            item.shootSpeed = 18f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));//change to reduce spread
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;

            return true;
        }
    }
}
