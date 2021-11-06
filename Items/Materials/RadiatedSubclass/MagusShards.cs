using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.RadiatedSubclass
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
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 38;
            item.height = 32;
            item.maxStack = 999;
            item.value = 1000;
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
