using HarmonyLib;

namespace Nyoxides_Card_Archive
{
    [HarmonyPatch(typeof(CompendiumSectionCards), "IsCardUnlockedAndDiscovered")]
    class ShowAllCompendiumCardsPatch
    {
        static bool Prefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}