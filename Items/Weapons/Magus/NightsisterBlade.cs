using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus
{
	public class NightsisterBlade : MagusDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightsister's Blade");
			Tooltip.SetDefault("Forged from the fury of the night\n Deals Venom\n Heals 10 life every time you do damage");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 59;
			item.width = 66;
			item.height = 66;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
            item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.DarkShard, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 320);
			player.statLife += 10; //Gives the player 5 hp. Can change it to be based off of damage
			player.HealEffect(10); //I think this just shows that the player is getting healed.
		}
    }
}