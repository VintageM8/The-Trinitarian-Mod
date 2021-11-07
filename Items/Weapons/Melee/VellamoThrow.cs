using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee
{
    public class VellamoThrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vellamo's Throw");
            Tooltip.SetDefault("Summons an array of ocean shards\nLegend says this was once wielded by a finnish goddess");
        }
        public override void SetDefaults()
        {
            item.channel = true;
            item.crit = 4;
            item.damage = 88;
            item.melee = true;
            item.width = 36;
            item.height = 48;
            item.useTime = 24;
            item.useAnimation = 24;
            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("VellamoThrowProjectile");
            item.shootSpeed = 2f;
        }
    }
}