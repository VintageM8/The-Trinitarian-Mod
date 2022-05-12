using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Weapon.Mage;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic
{
    public class WandF : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Frostburn");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.width = 26;
            Item.height = 28;
            Item.useTime = 27;
            Item.useAnimation = 27;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = Item.sellPrice(0, 0, 16, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<FrostSparking>();
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.WorkBenches)
                .AddIngredient(ItemID.BorealWood, 15)
                .AddIngredient(ItemID.Shiverthorn, 2)
                .Register();
        }
    }
}