using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.Minion;
using Trinitarian.Projectiles.Minions;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Summoner.PreHardmode
{
    public class NjorsMinion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Njor's Minion");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.knockBack = 3f;
            item.mana = 15;
            item.width = 32;
            item.height = 42;
            item.useTime = 36;
            item.useAnimation = 36;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.summon = true;
            item.buffType = BuffType<NjorMinionBuff>();
            item.shoot = ProjectileType<NjorMinion>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }
    }
}