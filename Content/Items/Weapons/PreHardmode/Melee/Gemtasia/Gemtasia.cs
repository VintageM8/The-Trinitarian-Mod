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
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 90, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<GemMadness>(), 60);
        }

        public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.Ruby, 2)
                .AddIngredient(ItemID.StoneBlock, 10)
                .AddIngredient(ItemID.Bone, 8)
                .AddIngredient(ItemID.Topaz, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}