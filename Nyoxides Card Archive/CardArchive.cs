using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using MonsterTrainModdingAPI.Builder;
using MonsterTrainModdingAPI.Managers;

namespace Nyoxides_Card_Archive
{
    [BepInPlugin("nyoxide.monstertrain.card-archive", "Nyoxide's Card Archive", "1.0.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class CardArchive : BaseUnityPlugin 
    {
        private static ConfigEntry<bool> _enable;
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Nyoxide's Logger");
        
        void Awake()
        {
            _enable = Config.Bind("General", "Enable Custom Cards", true, "If you set this to false, no custom cards will be added to the game from this mod.");
            var harmony = new Harmony("nyoxide.monstertrain.harmony");
            harmony.PatchAll();
            LoadCards();
        }
        
        public static void log(LogLevel lvl, string msg)
        {
            logger.Log(lvl, msg);
        }

        private static void LoadCards()
        {
            CustomCardManager.RegisterCustomCard(NyoBlastCreator.CreateCard());
        }
        
       
    }
}