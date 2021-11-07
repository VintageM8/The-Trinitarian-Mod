using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.RadiatedSubclass
{
    [AutoloadEquip(EquipType.Head)]
    public class PlutoniumMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plutonium Mask");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<UraniumPlate>() && legs.type == ItemType<UraniumBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants immunity to Venom but decreases defense by 3";
            player.buffImmune[BuffID.Venom] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Plutonium>(), 10);
            recipe.AddIngredient(ItemType<ToxicWaste>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
