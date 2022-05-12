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
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = false;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            Item.width = 38;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Red;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.FragmentVortex, 1)
                .AddTile(TileID.Furnaces)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Furnaces)
                .AddIngredient(ItemID.FragmentNebula, 1)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Furnaces)
                .AddIngredient(ItemID.FragmentSolar, 1)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Furnaces)
                .AddIngredient(ItemID.FragmentStardust, 1)
                .Register();
        }
    }
}
