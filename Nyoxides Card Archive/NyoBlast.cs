using HarmonyLib;
using MonsterTrainModdingAPI.Builder;
using MonsterTrainModdingAPI.Enum;

namespace Nyoxides_Card_Archive
{
    class NyoBlastCreator
    {
        public static CardDataBuilder CreateCard()
        {
            CardDataBuilder cardDataBuilder = new CardDataBuilder
            {
                CardID = "NyoBlast",
                Name = "Nyo-Blast",
                Cost = 6,
                OverrideDescriptionKey = "CardData_overrideDescriptionKey-ecb95717c140b89f-64f8b55236b461741b1feea18f971216-v2",
                TargetsRoom = true,
                Targetless = false
            };
            cardDataBuilder.CreateAndSetCardArtPrefabVariantRef(
                "Assets/GameData/Cards/Portrait_Prefabs/CardArt_Spell_Awoken_Smite.prefab",
                "c1ffdd3f20795fb46a210716ab0775fd"
            );
            cardDataBuilder.SetCardClan(MTClan.Hellhorned);
            cardDataBuilder.AddToCardPool(MTCardPool.StandardPool);

            var damageEffectBuilder = new CardEffectDataBuilder
            {
                EffectStateName = "CardEffectDamage",
                ParamInt = 500,
                TargetMode = TargetMode.DropTargetCharacter
            };
            cardDataBuilder.Effects.Add(damageEffectBuilder.Build());
            cardDataBuilder.Traits.Add(new CardTraitData{traitStateName = "CardTraitIgnoreArmor"});
            return cardDataBuilder;
        }
    }
}