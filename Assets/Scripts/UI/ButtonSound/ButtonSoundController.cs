using System;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ButtonSound
{
    public class ButtonSoundController : MonoBehaviour
    {
        [SerializeField] private HoverHandler hoverHandler;
        [SerializeField] private Button buttonToggleSound;

        [SerializeField] private GameObject objectViewUnmute;
        [SerializeField] private GameObject objectViewMute;

        [SerializeField] private GameObject[] objectsHover;
        [SerializeField] private GameObject[] objectsUnhover;

        private bool _isActiveSound = true;

        private void Start()
        {
            objectViewUnmute.SetActive(_isActiveSound);
            objectViewMute.SetActive(!_isActiveSound);
            ToggleViewButton(false);
        }

        private void OnEnable()
        {
            buttonToggleSound.onClick.AddListener(ToggleSound);

            hoverHandler.OnHover += ToggleViewButton;
        }

        private void OnDisable()
        {
            buttonToggleSound.onClick.RemoveListener(ToggleSound);
        }

        private void ToggleSound()
        {
            _isActiveSound = !_isActiveSound;

            objectViewUnmute.SetActive(_isActiveSound);
            objectViewMute.SetActive(!_isActiveSound);
        }

        private void ToggleViewButton(bool isHover)
        {
            foreach (var objectHover in objectsHover)
            {
                objectHover.SetActive(isHover);
            }

            foreach (var objectHover in objectsUnhover)
            {
                objectHover.SetActive(!isHover);
            }
        }
    }
}