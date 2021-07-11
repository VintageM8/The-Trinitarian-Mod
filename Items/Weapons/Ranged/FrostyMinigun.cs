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
            item.damage = 10;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 35;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Bullet;
        }
    }
}
