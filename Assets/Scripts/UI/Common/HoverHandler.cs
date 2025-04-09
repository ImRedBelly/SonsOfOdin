using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Common
{
    public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        public event Action<bool> OnHover;
        public event Action<bool> OnMove;

        public bool IsHovered { get; private set; }

        [SerializeField] private GameObject objectHover;
        [SerializeField] private GameObject objectUnhover;


        private void Start()
        {
            SetStateHover(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsHovered = true;
            OnHover?.Invoke(true);
            SetStateHover(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsHovered = false;
            OnHover?.Invoke(false);
            SetStateHover(false);
        }

        private void SetStateHover(bool isHover)
        {
            if (objectUnhover != null) objectUnhover.SetActive(!isHover);
            if (objectHover != null) objectHover.SetActive(isHover);
        }


        public void OnPointerMove(PointerEventData eventData)
        {
            if (eventData.delta.sqrMagnitude <= 2f)
            {
                OnMove?.Invoke(false);
            }
            else
            {
                OnMove?.Invoke(true);
            }
        }
    }
}