using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class VikingBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Viking Bow");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 250;
            item.useAnimation = 25;
            item.useTime = 25;
            item.width = 30;
            item.height = 60;
            item.shoot = AmmoID.Arrow;
            item.shootSpeed = 8f;
            item.knockBack = 10f;
            item.ranged = true;
            item.value = Item.sellPrice(gold: 78);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<UlvkilSoul>(), 4);
            recipe.AddIngredient(ItemType<StormEnergy>(), 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}