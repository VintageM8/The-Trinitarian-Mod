using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Elf
{
    public class ElfLVL6 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf: Level 6");
            Tooltip.SetDefault("Ranger\n Increases ranged damage by 25%, 20% Chance to not use ammo");
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
               player.rangedDamage += 0.25f;
               player.ammoCost80 = true;
            }
       }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddIngredient(ModContent.ItemType<ElfLVL5>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}