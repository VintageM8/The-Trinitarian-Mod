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
            Item.damage = 80;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 46;
            Item.height = 24;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.crit = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<WaterstormBubble>();
            Item.shootSpeed = 18f;
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
