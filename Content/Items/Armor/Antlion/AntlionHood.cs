using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.Antlion
{
    [AutoloadEquip(EquipType.Head)]
    public class AntlionHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Hood");
            Tooltip.SetDefault("Minion damage increased by 7%");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<AntlionPlate>() && legs.type == ItemType<AntlionBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Minion slot and you can run very fast (Like the hermes boots)";
            player.maxMinions += 1;
            player.accRunSpeed = 6f;
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.FossilOre, 1);
            recipe.AddIngredient(ItemID.Amber, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}