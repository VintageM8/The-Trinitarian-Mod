using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Body)]
    public class PlutoniumPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plutonium Plate");
            Tooltip.SetDefault("4% Increased magus damage.\n 3% increased crit chance");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 3, 80, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.04f;
            modPlayer.magusCrit += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Plutonium>(), 8);
            recipe.AddIngredient(ItemType<ToxicWaste>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}