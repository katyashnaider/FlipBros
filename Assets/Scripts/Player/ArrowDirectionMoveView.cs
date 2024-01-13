using FlipBros.Configs;
using FlipBros.Gameplay.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace FlipBros.Player
{
    public class ArrowDirectionMoveView : MonoBehaviour
    {
        [SerializeField] private Slider _arrowSlider;

        private IInput _input;

        private float _dragStartTime;
        private bool _isRunMoveArrow;
        private CharacterPlayerConfig _characterPlayerConfig;

        public void Construct(IInput input, CharacterPlayerConfig characterPlayerConfig)
        {
            _characterPlayerConfig = characterPlayerConfig;
            _input = input;
        }

        private void Update()
        {
            var isStartInputInThisFrame = IsStartInputInThisFrame();
            if (isStartInputInThisFrame)
            {
                _isRunMoveArrow = true;
                _arrowSlider.gameObject.SetActive(true);
                _dragStartTime = Time.time;
            }
            else if (LostInputInThisFrame())
            {
                _isRunMoveArrow = false;
                _arrowSlider.gameObject.SetActive(false);
            }

            if (_isRunMoveArrow)
            {
                var elapsedTime = Time.time - _dragStartTime;
                var currentProgress = Mathf.Clamp01(elapsedTime / _characterPlayerConfig.DurationToMaxPower);
                _arrowSlider.value = currentProgress;
            }

            bool IsStartInputInThisFrame()
            {
                return _input.HasAnyInput.Value && !_input.LastFrameHasAnyInput;
            }

            bool LostInputInThisFrame()
            {
                return _input.HasAnyInput.Value == false && _input.LastFrameHasAnyInput;
            }
        }
    }
}