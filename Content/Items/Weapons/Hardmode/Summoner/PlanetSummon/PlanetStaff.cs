using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Minion;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.PlanetSummon;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Summoner.PlanetSummon
{
    public class PlanetStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planet Staff");
            Tooltip.SetDefault("Summons a cute planet to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 69;
            Item.knockBack = 5f;
            Item.mana = 20;
            Item.width = 32;
            Item.height = 42;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 5, 50, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = BuffType<PlanetBuff>();
            Item.shoot = ProjectileType<PlanetMinion>();
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
                .AddIngredient(ItemID.FragmentStardust, 25)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}