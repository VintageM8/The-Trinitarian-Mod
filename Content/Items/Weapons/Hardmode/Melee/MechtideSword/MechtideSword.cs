using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Assets;
using Trinitarian.Content.Items.Materials.Bars;
using Microsoft.Xna.Framework;
using Trinitarian.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.MechtideSword
{
    public class MechtideSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechtide Sword");
            Tooltip.SetDefault("Each enemy slain builds your charge. Right click to release.");
            TrinitarianGlowmask.AddGlowMask(item.type, "Trinitarian/Content/Items/Weapons/Hardmode/Melee/MechtideSword/MechtideSword_Glow");
        }

        public override void SetDefaults()
        {
            item.damage = 70;
            item.melee = true;
            item.width = 84;
            item.height = 90;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            var modPlayer = player.GetModPlayer<TrinitarianPlayer>();

            if (target.life <= 0 && !target.SpawnedFromStatue)
            {
                modPlayer.MechtideCharge++;
                CombatText.NewText(target.getRect(), new Color(38, 126, 126), modPlayer.MechtideCharge, true, false);
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (Main.rand.NextBool(3)) {
				//Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<MechtideDust>());
			}
		}

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("Trinitarian/Content/Items/Weapons/Hardmode/Melee/MechtideSword/MechtideSword_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}