using Configs;
using DG.Tweening;
using Spine;
using Spine.Unity;
using TMPro;
using UI;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private CharacterConfig characterConfig;

    [SerializeField] private Button buttonRotateCard;
    [SerializeField] private Button buttonSoundCard;

    [SerializeField] private Transform foregroundCard;
    [SerializeField] private Transform backgroundCard;

    [SerializeField] private HoverHandler hoverHandler;
    [SerializeField] private SkeletonGraphic characterAnimation;
    [SerializeField] private SkeletonGraphic runeAnimation;
    [SerializeField] private SkeletonGraphic avatarAnimation;

    [SerializeField] private Image avatarBackgroundCharacter;
    [SerializeField] private Image avatarForegroundCharacter;
    [SerializeField] private Image iconMainSkill;
    [SerializeField] private Image[] iconsSkillWithLine;
    [SerializeField] private Image[] iconsSkillWithOutLine;
    [SerializeField] private TMP_Text textNameCharacter;
    [SerializeField] private TMP_Text textDescriptionCharacter;
    [SerializeField] private TMP_Text textFamilyCharacter;

    private bool _isViewBackground;

    private void OnEnable()
    {
        buttonRotateCard.onClick.AddListener(OnRotateCard);
        if (hoverHandler != null) hoverHandler.OnHover += OnHoveredCard;
        if (hoverHandler != null) hoverHandler.OnMove += OnDragCursor;


        OnHoveredCard(false);
    }

    private void OnDisable()
    {
        buttonRotateCard.onClick.RemoveListener(OnRotateCard);
        if (hoverHandler != null) hoverHandler.OnHover -= OnHoveredCard;
        if (hoverHandler != null) hoverHandler.OnMove -= OnDragCursor;
    }


    private void OnHoveredCard(bool isHovered)
    {
        if (isHovered)
        {
            TooltipController.Instance.SetTextDescription(characterConfig.textDescription);
            if (characterAnimation != null)
            {
                characterAnimation.AnimationState.SetAnimation(0, "in", true);
            }

            if (runeAnimation != null)
            {
                TrackEntry track = runeAnimation.AnimationState.SetAnimation(0, "action", false);
                track.Complete += ClearRuneAnimation;

                void ClearRuneAnimation(TrackEntry trackEntry)
                {
                    track.Complete -= ClearRuneAnimation;
                    runeAnimation.AnimationState.ClearTracks();
                }
            }
        }
        else
        {
            if (characterAnimation != null)
            {
                characterAnimation.AnimationState.SetAnimation(0, "idle", true);
            }
        }
    }

    private void OnDragCursor(bool isDrag)
    {
        if (!isDrag && hoverHandler.IsHovered)
        {
            TooltipController.Instance.EnableTooltip();
        }
        else
        {
            TooltipController.Instance.DisableTooltip();
        }
    }

    private void OnRotateCard()
    {
        _isViewBackground = !_isViewBackground;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one * 1.05f, .2f).SetEase(Ease.OutCubic));
        sequence.Append(transform.DORotate(new Vector3(0, 90, 0), .15f).SetEase(Ease.OutCubic));
        sequence.AppendCallback(() =>
        {
            foregroundCard.gameObject.SetActive(!_isViewBackground);
            backgroundCard.gameObject.SetActive(_isViewBackground);

            if (_isViewBackground)
            {
                avatarAnimation.AnimationState.SetAnimation(0, "animation", true);
            }
            else
            {
                avatarAnimation.AnimationState.ClearTracks();
            }
        });
        sequence.Append(transform.DORotate(new Vector3(0, 0, 0), .15f).SetEase(Ease.InCubic));
        sequence.Append(transform.DOScale(Vector3.one, .2f).SetEase(Ease.InCubic));
    }

    private void OnValidate()
    {
        if (characterConfig)
        {
            if (avatarBackgroundCharacter)
            {
                avatarBackgroundCharacter.color = characterConfig.colorAvatarBackgrounds;
            }

            if (avatarForegroundCharacter)
            {
                avatarForegroundCharacter.color = characterConfig.colorAvatarBackgrounds;
            }

            if (characterAnimation != null && characterConfig.characterSkeletonData != null)
            {
                characterAnimation.skeletonDataAsset = characterConfig.characterSkeletonData;
                characterAnimation.Initialize(true);
            }

            if (runeAnimation != null && characterConfig.runeSkeletonData != null)
            {
                runeAnimation.skeletonDataAsset = characterConfig.runeSkeletonData;
                runeAnimation.Initialize(true);
            }

            if (avatarAnimation != null && characterConfig.avatarSkeletonData != null)
            {
                avatarAnimation.skeletonDataAsset = characterConfig.avatarSkeletonData;
                avatarAnimation.Initialize(true);
            }

            if (characterConfig.spriteRuneWithLine)
            {
                foreach (var iconSkill in iconsSkillWithLine)
                {
                    iconSkill.sprite = characterConfig.spriteRuneWithLine;
                }
            }

            if (characterConfig.spriteRunWithOutline)
            {
                foreach (var iconSkill in iconsSkillWithOutLine)
                {
                    iconSkill.sprite = characterConfig.spriteRunWithOutline;
                }
            }

            if (characterConfig.spriteMainSkill)
            {
                iconMainSkill.sprite = characterConfig.spriteMainSkill;
            }

            if (textNameCharacter && !string.IsNullOrEmpty(characterConfig.nameCharacter))
            {
                textNameCharacter.SetText(characterConfig.nameCharacter);
            }

            if (textDescriptionCharacter && !string.IsNullOrEmpty(characterConfig.descriptionCharacter))
            {
                textDescriptionCharacter.SetText(characterConfig.descriptionCharacter);
            }

            if (textFamilyCharacter && !string.IsNullOrEmpty(characterConfig.familyCharacter))
            {
                textFamilyCharacter.SetText(characterConfig.familyCharacter);
            }
        }
    }
}