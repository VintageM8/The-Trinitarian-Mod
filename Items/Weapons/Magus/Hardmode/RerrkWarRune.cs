using Trinitarian.Projectiles.Magus;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Terraria;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class RerrkWarRune : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rerrk's Power");
            Tooltip.SetDefault("All players in the aura become angry and regen life, However more monsters are attracted to you,\n" +
                "However more monsters are attracted to you.\n" +
                "Created from Rerrk himself and only Rerrk can use its full power.");
        }

        public override void SetDefaults()
        {
            item.damage = 63;
            item.width = 42;
            item.noUseGraphic = true;
            item.height = 42;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 20;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.UseSound = SoundID.Item103;
            item.consumable = false;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<RerrkRune>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 6;
        }

    }
}