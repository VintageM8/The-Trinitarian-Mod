using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Subclasses.Necro;

namespace Trinitarian.Subclasses.Necro
{
    public class NecromancerLVL5 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer: Level 5");
            Tooltip.SetDefault("Summoner\n Increases summon damage by 18%, and increased summon slots by 5.");
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
                player.minionDamage += 0.18f;
                player.maxMinions += 5;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
            recipe.AddIngredient(ModContent.ItemType<NecromancerLVL4>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
