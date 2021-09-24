using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Magus
{
    public class Preformation : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Preformation");
            Tooltip.SetDefault("Automatically turns wooden arrows in cursed flame arrows");

        }

        public override void SafeSetDefaults()
        {
            item.damage = 12;
            item.noMelee = true;
            item.width = 18;
            item.height = 40;
            item.useTime = 26;
            item.useAnimation = 26;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.CursedArrow;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 22);
            recipe.AddIngredient(ModContent.ItemType<UraniumBar>(), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}