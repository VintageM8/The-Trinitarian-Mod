using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Legs)]
    public class PlutoniumLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plutonium Leggings");
            Tooltip.SetDefault("3% increased magus damage and crit\n5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 11;
        }

        public override void UpdateEquip(Player player)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.03f;
            modPlayer.magusCrit += 3;
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Plutonium>(), 5);
            recipe.AddIngredient(ItemType<ToxicWaste>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}