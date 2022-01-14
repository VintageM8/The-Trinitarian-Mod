using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.FrostedSpirit
{
	public class FrozenRemains : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frozen Remains");
			Tooltip.SetDefault("An essance of the frozen tundra lives in here\nUse this item to obtain your Wizard Token.");
		}

		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 10;
			item.maxStack = 1;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
		}
	}
}