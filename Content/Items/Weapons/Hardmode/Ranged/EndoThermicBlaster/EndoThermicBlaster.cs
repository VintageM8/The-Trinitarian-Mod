using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.EndoThermicBlaster
{
    public class EndoThermicBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endothermic Blaster");
            Tooltip.SetDefault("Your effects are boosted in the Snow Biome\nFreeze! Don't move!");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 50;
            item.height = 50;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<EndothermicProj>();
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<IceShards>(), 28);
            recipe.AddIngredient(ItemID.SoulofLight, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
