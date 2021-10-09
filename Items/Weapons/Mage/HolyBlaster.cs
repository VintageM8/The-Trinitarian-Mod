using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Mage
{
    public class HolyBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Blaster");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.noMelee = true;
            item.magic = true;
            item.autoReuse = true;
            item.mana = 10;
            item.knockBack = 3f;
            item.rare = ItemRarityID.Green;
            item.width = 38;
            item.height = 24;
            item.useTime = 17;
            item.useAnimation = 17;
            item.UseSound = SoundID.Item12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 16f;
            item.shoot = ProjectileType<Laser>();
            item.value = Item.sellPrice(0, 0, 70, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StarSteel>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}