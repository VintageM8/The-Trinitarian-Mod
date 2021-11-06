using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Subclasses.Necro
{
    public class Necro1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necromancer Ability | 1");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.knockBack = 5f;
            item.mana = 12;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffID.Ravens;
            item.shoot = ProjectileID.Raven;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 80);
            recipe.AddIngredient(ModContent.ItemType<SummonShards>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}