using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Mage
{
    public class MushroomStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 49;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 23, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Mushrooms>();
            item.shootSpeed = 18f;
        }
    }
}