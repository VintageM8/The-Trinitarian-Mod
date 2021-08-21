using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
    public class IceSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosted Katana");
            Tooltip.SetDefault("Frosty, still slices foes like butter.");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.melee = true;
            item.width = 40; 
            item.height = 40; 
            item.useTime = 23;
            item.useAnimation = 23;
            item.knockBack = 3f;
            item.value = Item.buyPrice(gold: 4);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 320);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemType<IceShards>(), 8);
            recipe.AddIngredient(ItemID.Katana);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}