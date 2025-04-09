using TMPro;
using UnityEngine;

namespace UI
{
    public class TooltipController : MonoBehaviour
    {
        public static TooltipController Instance;

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private TMP_Text textDescription;

        private Vector3 _lastPositionCursor;
        private float _currentTime;
        private bool _isEnable;

        private void Awake()
        {
            Instance = this;
        }

        public void EnableTooltip()
        {
            _currentTime = 4;
            _isEnable = true;
        }


        public void DisableTooltip()
        {
            canvasGroup.alpha = 0;
            _isEnable = false;
        }

        public void SetTextDescription(string description)
        {
            textDescription.SetText(description);
        }

        void Start()
        {
            DisableTooltip();
        }

        void Update()
        {
            if (_isEnable)
            {
                if ((_lastPositionCursor - Input.mousePosition).sqrMagnitude < 1)
                {
                    _currentTime -= Time.deltaTime;
                    if (_currentTime <= 0)
                    {
                        canvasGroup.alpha = 1;
                    }
                }

                _lastPositionCursor = Input.mousePosition;
                transform.position = _lastPositionCursor + offsetPosition;
            }
        }
    }
}