using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus
{
    public class ZozarDagger : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zozar's Dagger");
            Tooltip.SetDefault("Shoots out throwing knives");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 58;
            item.width = 10;
            item.height = 24;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 1, 80, 0);
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<ThrowingKnife>();
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.TitaniumBar, 14);
            recipe.AddIngredient(ModContent.ItemType<VikingMetal>(), 8);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.SoulofNight, 15);
            recipe2.AddIngredient(ItemID.AdamantiteBar, 14);
            recipe2.AddIngredient(ModContent.ItemType<VikingMetal>(), 8);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}