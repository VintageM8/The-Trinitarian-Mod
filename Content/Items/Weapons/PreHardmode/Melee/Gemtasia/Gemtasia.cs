using Terraria.ID;
using Terraria;
using Trinitarian.Content.Buffs.Damage;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.Gemtasia
{
	public class Gemtasia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemtasia");
			Tooltip.SetDefault("Power of the Gem stuns your foes");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 12;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 90, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<GemMadness>(), 60);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddIngredient(ItemID.Bone, 8);
            recipe.AddIngredient(ItemID.Topaz, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}