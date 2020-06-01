using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using MonsterTrainModdingAPI.Builder;
using MonsterTrainModdingAPI.Models;

namespace Nyoxides_Card_Archive
{
    [BepInPlugin("nyoxide.monstertrain.card-archive", "Nyoxide's Card Archive", "1.0.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class CardArchive : BaseUnityPlugin, TrainModule 
    {
        private static ConfigEntry<bool> _enable;
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
        
        public List<CardDataBuilder> RegisterCustomCards()
        {
            if (!_enable.Value)
            {
                return null;
            }
            log(LogLevel.Debug, "Adding custom cards...");
            var list = new List<CardDataBuilder>();
            list.Add(NyoBlastCreator.CreateCard());
            return list;
        }

        public List<RelicData> RegisterCustomArtifacts()
        {
            return null;
        }

        public List<CharacterData> RegisterCustomCharacters()
        {
            return null;
        }

        public BaseUnityPlugin RegisterPlugin()
        {
            return this;
        }
    }
}