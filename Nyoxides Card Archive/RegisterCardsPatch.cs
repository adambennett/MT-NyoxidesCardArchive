using HarmonyLib;

namespace Nyoxides_Card_Archive
{
    public class RegisterCardsPatch
    {
        [HarmonyPatch(typeof(SaveManager), "Initialize")]
        class RegisterNotHornBreak
        {
            static void Postfix(ref SaveManager __instance)
            {
                AllGameData allGameData = __instance.GetAllGameData();
                if (CardArchive._enable.Value)
                {
                    NyoBlastCreator.CreateCard(allGameData);
                }
            }
        }
    }
}