using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Necro
{
    public class NecromancerLVL2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer: Level 2");
            Tooltip.SetDefault("Summoner\n Increases summon damage by 6%, and increased summon slots by 2.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
		{
			if (base.item.favorited)
			{
               player.minionDamage += 0.6f;
               player.maxMinions += 2;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 45);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}