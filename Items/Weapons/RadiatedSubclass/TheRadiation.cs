using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;

namespace Trinitarian.Items.Weapons.RadiatedSubclass
{
    public class TheRadiation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Radiation");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.width = 42;
            item.height = 48;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 320);
        }

    }
}