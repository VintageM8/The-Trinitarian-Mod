using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class BlossomedBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blossomed Bow");
            Tooltip.SetDefault("Does random stuff with your arrow");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = 5;
            Item.knockBack = 5;
            Item.value = 231426;
            Item.rare = 7;
            Item.UseSound = SoundID.Item5;
            Item.width = 32;
            Item.height = 74;
            Item.shoot = 40;
            Item.useAmmo = 40;
            Item.shootSpeed = 4;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return base.CanConsumeAmmo(ammo, player);
        }
    }
}