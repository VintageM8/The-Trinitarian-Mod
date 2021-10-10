using Terraria.ModLoader;

namespace Trinitarian
{
    public class Trinitarian : Mod
    {
	    public static Trinitarian Mod { get; set; }
	    public Trinitarian()
	    {
		    Mod = this;
	    }
	    public override void Unload()
	    {
		    Mod = null;
	    }
    }
}
