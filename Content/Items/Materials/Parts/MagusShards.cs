using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Parts
{
    public class MagusShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galactic Souls");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 38;
            item.height = 32;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Furnaces);
            recipe2.AddIngredient(ItemID.FragmentNebula, 1);
            recipe2.SetResult(this);
            recipe2.AddRecipe();

            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddTile(TileID.Furnaces);
            recipe3.AddIngredient(ItemID.FragmentSolar, 1);
            recipe3.SetResult(this);
            recipe3.AddRecipe();

            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.AddIngredient(ItemID.FragmentStardust, 1);
            recipe4.SetResult(this);
            recipe4.AddRecipe();
        }
    }
}
