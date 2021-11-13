using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Elf
{
    public class ElfLVL1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf: Level 1");
            Tooltip.SetDefault("Ranger\n Increases ranged damage by 2%, and increased speed cost by 4%.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
		{
			if (base.item.favorited)
			{
               player.rangedDamage += 0.3f;
               player.moveSpeed += 0.02f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}