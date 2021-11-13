using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Necro
{
    public class NecromancerLVL3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer: Level 3");
            Tooltip.SetDefault("Summoner\n Increases summon damage by 10%, and increased summon slots by 3.");
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
               player.minionDamage += 0.9f;
               player.maxMinions += 3;
            } 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 28);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}