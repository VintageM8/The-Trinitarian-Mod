using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.Minion;
using Trinitarian.Projectiles.Minions;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Summoner.PreHardmode
{
    public class FleshyWallStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fleshy Wall Staff");
            Tooltip.SetDefault("Summons a blob of flesh to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 19;
            item.knockBack = 5f;
            item.mana = 12;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<FleshyWallBuff>();
            item.shoot = ProjectileType<FleshyWallMinion>();
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
            recipe.AddIngredient(ModContent.ItemType<StarSteel>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SummonShards>(), 5);
            recipe.AddIngredient(ItemID.ObsidianRose, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}