using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Minion;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.FrostDragon;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Summoner.FrostDragon
{
    public class FrostDragon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of the Frost Dragon");
            Tooltip.SetDefault("Summons a frozen dragon to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.knockBack = 5f;
            Item.mana = 20;
            Item.width = 32;
            Item.height = 42;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 15, 50, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = BuffType<IceDragBuff>();
            Item.shoot = ProjectileType<FrostDragonproj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(Item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<TrueStarSteel>(), 18)
                .AddIngredient(ModContent.ItemType<SummonShards>(), 8)
                .AddIngredient(ModContent.ItemType<EnchantedIceBall>(), 2)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}