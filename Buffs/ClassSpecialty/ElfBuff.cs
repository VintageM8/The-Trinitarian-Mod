using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Trinitarian.Buffs.ClassSpecialty
{
    public class ElfBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Forest's Blessing");
            Description.SetDefault("Your speed is being increased");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.09f;
        }
    }
}