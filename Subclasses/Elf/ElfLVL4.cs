using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Elf
{
    public class ElfLVL4 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf: Level 4");
            Tooltip.SetDefault("Ranger\n Increases ranged damage by 11%, and increased speed cost by 7%.");
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
               player.rangedDamage += 0.11f;
               player.moveSpeed += 0.07f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 4);
            recipe.AddIngredient(ModContent.ItemType<ElfLVL3>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}