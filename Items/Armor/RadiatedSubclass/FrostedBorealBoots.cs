using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Legs)]
    public class FrostedBorealBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosted Boreal Boots");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 0, 0, 40);
            item.rare = ItemRarityID.Green;
            item.defense = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<IceShards>(), 3);
            recipe.AddIngredient(ItemID.BorealWoodGreaves, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}