using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.Minion;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Minions;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Summoner.Hardmode
{
    public class MechtideSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Staff");
            Tooltip.SetDefault("Summons an entity of pure mechtide to fight for you.");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 35;
            item.knockBack = 5f;
            item.mana = 100;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 38, 50, 0);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<PureMechtideBuff>();
            item.shoot = ProjectileType<PureMechtide>();
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
            recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 12);
            recipe.AddIngredient(ModContent.ItemType<TrueStarSteel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<SummonShards>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}