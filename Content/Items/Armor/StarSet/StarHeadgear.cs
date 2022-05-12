using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Armor.StarSet
{
    [AutoloadEquip(EquipType.Head)]
    public class StarHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Headgear");
            Tooltip.SetDefault("Mana cos reduced by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.manaCost -= 0.1f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<StarPlate>() && legs.type == ItemType<StarBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "80 more mana and increased mana regen\nWhen you are hit, you release a star.";
            player.manaRegen += 2;
            player.statManaMax2 += 80;

            player.GetModPlayer<TrinitarianPlayer>().StarSet = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MeteoriteBar, 12)
                .AddIngredient(ItemType<StarSteel>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}