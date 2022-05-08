using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Minion;
using Trinitarian.Content.Items.Weapons.Hardmode.Summoner.GiantFish;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Summoner.GiantFish
{
    public class GiantFishStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giant Fish Staff");
            Tooltip.SetDefault("Summons a giant fish to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.knockBack = 5f;
            Item.mana = 12;
            Item.width = 32;
            Item.height = 42;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = BuffType<FishBuff>();
            Item.shoot = ProjectileType<GiantFish>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            player.AddBuff(Item.buffType, 2);
            position = Main.MouseWorld;
        }
    }
}