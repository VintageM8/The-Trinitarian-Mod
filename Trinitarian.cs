using Terraria.ModLoader;

namespace Trinitarian
{
    public class Trinitarian : Mod
    {
	    public static Trinitarian Mod { get; set; }
	     public static ModHotKey UseAbilty;
	    public Trinitarian()
	    {
		    Mod = this;
		    
	    }
	    public override void Unload()
	    {
		    Mod = null;
		      UseAbilty = null;
	    }
	    public override void Load()
        {
	 UseAbilty = RegisterHotKey("Use Abilty", "R");
	}
    }
}
