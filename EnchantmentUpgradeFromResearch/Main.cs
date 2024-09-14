using Kitchen;
using KitchenData;
using KitchenMods;

namespace EnchantmentUpgradeFromResearch
{
    public class Main : GenericSystemBase, IModSystem
    {
        internal const int RESEARCH_DESK = 1139247360;
        internal const int ENCHANTING_DESK = -292467039;
        internal const int BLUEPRINT_DESK = 1446975727;
        internal const int DISCOUNT_DESK = 1586911545;

        Appliance? researchDesk;
        Appliance? enchantingDesk;
        Appliance? blueprintDesk;
        Appliance? discountDesk;

        protected override void Initialise()
        {
            base.Initialise();

            Log("Initialising...");

            researchDesk = GameData.Main.Get<Appliance>(RESEARCH_DESK);
            enchantingDesk = GameData.Main.Get<Appliance>(ENCHANTING_DESK);
            blueprintDesk = GameData.Main.Get<Appliance>(BLUEPRINT_DESK);
            discountDesk = GameData.Main.Get<Appliance>(DISCOUNT_DESK);

            researchDesk.Upgrades.Add(enchantingDesk);

            blueprintDesk.Upgrades.Remove(discountDesk);
            blueprintDesk.Upgrades.Add(enchantingDesk);

            enchantingDesk.Upgrades.Add(discountDesk);

            Log("Completed!");
        }

        protected override void OnUpdate()
        {
        }

        internal static void Log(object text)
        {
            KitchenLogger.Log(text.ToString(), "EnchantmentUpgrades");
        }
    }
}