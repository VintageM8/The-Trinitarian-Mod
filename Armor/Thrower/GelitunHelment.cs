using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Armor.Thrower;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.Thrower
{
    [AutoloadEquip(EquipType.Head)]
    public class GelitunHelment : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelitun Helment");
            Tooltip.SetDefault("22% increased throwing velocity");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<GelitunChestplate>() && legs.type == ItemType<GelitunPants>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Player speed increased by 5%";
            player.moveSpeed += 0.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.AddIngredient(ItemID.PinkGel, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.Gel, 25);
            recipe2.AddIngredient(ItemID.PinkGel, 5);
            recipe2.AddIngredient(ItemID.LeadBar, 8);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}