using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Common
{
    public class ButtonClickAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector3 _startScale;

        private void Start()
        {
            _startScale = transform.localScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.localScale = _startScale * 0.9f;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = _startScale;
        }
    }
}