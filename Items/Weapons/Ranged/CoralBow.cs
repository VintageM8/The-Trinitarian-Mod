using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class CoralBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Bow");
            Tooltip.SetDefault("Launches Seashells that speeds up over time\nThe Seashell will also break into smaller shards when hit");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item67;
            item.crit = 4;
            item.damage = 15;
            item.ranged = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 65;
            item.useAnimation = 65;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CoralBowProj");
            item.shootSpeed = 11f;
        }
    }
}