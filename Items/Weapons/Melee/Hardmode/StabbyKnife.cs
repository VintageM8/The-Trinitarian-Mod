using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee.Hardmode
{
    public class StabbyKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stabby Knife");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
    }
}