using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.EndoThermicBlaster
{
    public class EndoThermicBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endothermic Blaster");
            Tooltip.SetDefault("Your effects are boosted in the Snow Biome\nFreeze! Don't move!");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<EndothermicProj>();
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<IceShards>(), 28)
                .AddIngredient(ItemID.SoulofLight, 14)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
