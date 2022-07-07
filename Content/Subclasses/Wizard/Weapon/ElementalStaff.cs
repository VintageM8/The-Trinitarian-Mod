using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Wizard;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class ElementalStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 16;
            Item.width = 34;
            Item.height = 34;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.channel = true;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<WaterBubble>();
            Item.shootSpeed = 10f;
        }
    }
}