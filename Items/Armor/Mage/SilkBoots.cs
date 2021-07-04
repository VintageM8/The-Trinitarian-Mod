using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Armor.Mage
{
	[AutoloadEquip(EquipType.Legs)]
	public class SilkBoots : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silk Boots");
			Tooltip.SetDefault("5% Increased Mana Damage\n Gives 40 mana.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 16;
			item.value = Item.sellPrice(0, 1, 50, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 45);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}