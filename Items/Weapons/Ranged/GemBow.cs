using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class GemBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Bow");
            Tooltip.SetDefault("Shoots out 3 arrows at a time");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.noMelee = true;
            item.ranged = true;
            item.width = 16;
            item.height = 36;
            item.useTime = 4;
            item.useAnimation = 12;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.reuseDelay = 14;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 8);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddIngredient(ItemID.Topaz, 2);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}