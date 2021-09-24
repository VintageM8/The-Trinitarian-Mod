using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class FrostyMinigun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosty Minigun");
            Tooltip.SetDefault("Shoots bullets out at high speed");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 35;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 27f;
            item.useAmmo = AmmoID.Bullet;
        }
    }
}
