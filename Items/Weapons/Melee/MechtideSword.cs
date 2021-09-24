using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
	public class MechtideSword : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Sword"); 
            Tooltip.SetDefault("From the heart of death");
		}

        public override void SetDefaults()
        {
            item.damage = 70;
            item.melee = true;
            item.width = 47;
            item.height = 47;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 8;
            item.value = Item.buyPrice(gold: 1);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 180);
            target.AddBuff(BuffID.Poisoned, 180);
            target.AddBuff(BuffID.Burning, 180);
        }
       
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}