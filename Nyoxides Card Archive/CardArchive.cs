using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace Nyoxides_Card_Archive
{
    [BepInPlugin("nyoxide.monstertrain.card-archive", "Nyoxide's Card Archive", "1.0.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class CardArchive : BaseUnityPlugin
    {
        public static ConfigEntry<bool> _enable;
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Nyoxide's Logger");
        
        void Awake()
        {
            _enable = Config.Bind("General", "Enable Custom Cards", true, "If you set this to false, no custom cards will be added to the game from this mod.");
            var harmony = new Harmony("nyoxide.monstertrain.harmony");
            harmony.PatchAll();
        }

        public static void log(LogLevel lvl, string msg)
        {
            logger.Log(lvl, msg);
        }
    }
}