using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class RustedBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rusted Bow");
		}

		public override void SetDefaults()
		{
			item.damage = 6;
			item.noMelee = true;
			item.ranged = true;
            item.width = 16;
            item.height = 36;
            item.useTime = 26;
            item.useAnimation = 26;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<RustyMetal>(), 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}