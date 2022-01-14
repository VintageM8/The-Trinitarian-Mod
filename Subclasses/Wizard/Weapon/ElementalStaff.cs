using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;

namespace Trinitarian.Subclasses.Wizard.Weapon
{
    public class ElementalStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 29;
            item.magic = true;
            item.mana = 16;
            item.width = 34;
            item.height = 34;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<WaterBubble>();
            item.shootSpeed = 10f;
        }
    }
}