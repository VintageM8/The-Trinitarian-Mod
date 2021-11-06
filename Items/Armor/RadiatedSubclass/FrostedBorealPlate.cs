using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Body)]
    public class FrostedBorealPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosted Boreal Plate");
            Tooltip.SetDefault("Increases magus damage by 2%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.02f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<IceShards>(), 5);
            recipe.AddIngredient(ItemID.BorealWoodBreastplate, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}