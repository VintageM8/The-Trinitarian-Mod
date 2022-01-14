using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.ForestEye
{
	public class Pupil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Pupil");
			Tooltip.SetDefault("Use this item to obtain your Elf Token.");
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