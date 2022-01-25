using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Head)]
    public class OceanHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Helm");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<OceanPlate>() && legs.type == ItemType<OceanBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases magus crit by 5%\nYou can now breath underwater";
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusCrit += 5;
            player.gills = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 12);
            recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

             ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.ShadowScale, 5);
            recipe.AddIngredient(ModContent.ItemType<OceanBar>(), 12);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}