using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Projectiles.RadiatedSubclass;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.RadiatedSubclass
{
    public class SmolderingKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smoldering Knife");
            Tooltip.SetDefault("Inficts OnFire! and Poisoned");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.width = 10;
            item.height = 24;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 0, 22, 0);
            item.rare = ItemRarityID.Blue;
            item.maxStack = 999;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<SmolderingKnifeproj>();
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 5);
            recipe.AddIngredient(ModContent.ItemType<FirePart>(), 1);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}