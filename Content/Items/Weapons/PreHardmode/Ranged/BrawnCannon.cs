using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class BrawnCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brawn Cannon");
            Tooltip.SetDefault("Shoots out fire\nUses gel as ammo");
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 44;
            Item.height = 16;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Flames;
            Item.shootSpeed = 5f;
            Item.useAmmo = AmmoID.Gel;
            Item.scale = 1.15f;
        }


        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddIngredient(ItemID.TissueSample, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}