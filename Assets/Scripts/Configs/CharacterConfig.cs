using Spine.Unity;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/CharacterConfig/Crate", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public SkeletonDataAsset characterSkeletonData;
        public SkeletonDataAsset runeSkeletonData;
        public SkeletonDataAsset avatarSkeletonData;
        
        public Sprite spriteRuneWithLine;
        public Sprite spriteRunWithOutline;
        public Sprite spriteMainSkill;
        public Color colorAvatarBackgrounds;
        
        public string nameCharacter;
        public string descriptionCharacter;
        public string familyCharacter;
        public string textDescription;
    }
}