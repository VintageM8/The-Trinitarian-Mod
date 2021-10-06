using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace Trinitarian.Items.Materials.Parts
{
	public class AlgaeItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Algae");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 20;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(0, 0, 0, 10);
            item.maxStack = 999;
        }

       
    }
}
