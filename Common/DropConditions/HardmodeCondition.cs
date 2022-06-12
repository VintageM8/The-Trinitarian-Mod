using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace Trinitarian.Common.DropConditions; 

public class HardmodeCondition : IItemDropRuleCondition {
    public bool CanDrop(DropAttemptInfo info)
    {
        return CanShowItemDropInUI();
    }

    public bool CanShowItemDropInUI()
    {
        return Main.hardMode;
    }

    public string GetConditionDescription()
    {
        return null;
    }
}