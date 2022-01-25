using Terraria.ID;
using Terraria;
using Trinitarian.Buffs;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Melee.PreHardmode
{
	public class Gemtasia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemtasia");
			Tooltip.SetDefault("Diamonds, rubies, topaz, they arnt just for mages");
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
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<GemMadness>(), 320);
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