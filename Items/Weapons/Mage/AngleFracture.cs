using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Mage
{
    public class AngleFracture : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Angle Fracture");
            Tooltip.SetDefault("A prehardmode Sky Fracture");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.magic = true;
            item.mana = 14;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.SkyFracture;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StarSteel>(), 8);
            recipe.AddIngredient(ItemType<PToken>(), 2);
            recipe.AddIngredient(ItemID.Feather, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}