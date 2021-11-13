using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Mage
{
    public class OceanCurse : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curse of the Ocean");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 58;
            item.magic = true;
            item.mana = 16;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 50, 60, 70);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<OceanCurseProj>();
            item.shootSpeed = 8f;
        }
    }
}