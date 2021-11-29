using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.Minion;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Projectiles.Minions;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Summoner.Hardmode
{
    public class HolyElemental : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Staff");
            Tooltip.SetDefault("Summons a cute Elemental to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.knockBack = 3f;
            item.mana = 10;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 3, 50, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<HEMinionBuff>();
            item.shoot = ProjectileType<HolyElementalMinion>();
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
            recipe.AddIngredient(ModContent.ItemType<TrueStarSteel>(), 18);
            recipe.AddIngredient(ModContent.ItemType<SummonShards>(), 8);
            recipe.AddIngredient(ItemID.LightShard, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}