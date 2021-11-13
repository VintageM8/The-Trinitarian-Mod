using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee
{
    public class PosidenTrident : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Posiden's Trident");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 56;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Trident>();
            item.shootSpeed = 10f;
        }
    }
}