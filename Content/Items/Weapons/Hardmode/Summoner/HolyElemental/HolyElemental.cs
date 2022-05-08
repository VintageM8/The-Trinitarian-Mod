using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Minion;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.HolyElemental;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Summoner.HolyElemental
{
    public class HolyElemental : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Staff");
            Tooltip.SetDefault("Summons a cute Elemental to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.knockBack = 3f;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 42;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = BuffType<HEMinionBuff>();
            Item.shoot = ProjectileType<HolyElementalMinion>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            position = Main.MouseWorld;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<TrueStarSteel>(), 18)
                .AddIngredient(ModContent.ItemType<SummonShards>(), 8)
                .AddIngredient(ItemID.LightShard, 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}