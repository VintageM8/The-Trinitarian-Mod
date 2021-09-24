using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs;
using Trinitarian.Projectiles.Minions;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Summoner
{
    public class FrostDragon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of the Frost Dragon");
            Tooltip.SetDefault("Summons a frozen dragon to fight for you\nthis uses another summon buff cause im lazy, will make one later");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.knockBack = 5f;
            item.mana = 20;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 15, 50, 0);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<PlanetBuff>();
            item.shoot = ProjectileType<FrostDragonproj>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }
    }
}