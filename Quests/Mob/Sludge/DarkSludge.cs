﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Mob.Sludge
{
	public class DarkSludge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Sludge");
			Tooltip.SetDefault("An part of an evil slime thing, yea gross.\nUse this item to obtain your Paladin Token.");
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