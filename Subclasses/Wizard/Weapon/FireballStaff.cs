using Microsoft.Xna.Framework;
using Trinitarian.Projectiles.Mage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Wizard.Weapon
{
    public class FireballStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball Staff");
            Tooltip.SetDefault("Playing with fire, deal with it.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Blue;
            item.mana = 5;
            item.UseSound = SoundID.Item21;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 15;
            item.useTurn = false;
            item.useAnimation = 16;
            item.useTime = 16;
            item.width = 50;
            item.height = 56;
            item.shoot = ModContent.ProjectileType<FireStaffProj>();
            item.shootSpeed = 8f;
            item.knockBack = 3f;
            item.magic = true;
            item.value = Item.sellPrice(gold: 1, silver: 75);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}