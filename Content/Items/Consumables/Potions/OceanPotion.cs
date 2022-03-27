using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Potion;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Consumables.Potions
{
    public class OceanPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essance of the Ocean");
            Tooltip.SetDefault("Your stats increase in the Ocean Biome.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 99;
            item.consumable = false;
            item.rare = ItemRarityID.Orange;
            item.buffType = ModContent.BuffType<OceanEssanceBuff>();
            item.buffTime = 7200;
            item.value = Item.sellPrice(0, 0, 80, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coal, 1);
            recipe.AddIngredient(ItemID.SandBlock, 2);
            recipe.AddIngredient(ModContent.ItemType<Algae>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}