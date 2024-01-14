using FlipBros.Configs;
using FlipBros.Gameplay.Inputs;
using UniRx;
using UnityEngine;

namespace FlipBros.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private float _maxPushForce = 20f;
        [SerializeField] private float _rotationForce = 10f;
        [SerializeField] private float _gravity = -12f;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ArrowDirectionMoveView _arrowDirectionMoveView;

        private readonly CompositeDisposable _lifeCycleDisposable = new CompositeDisposable();

        private float _startInputTime;

        private IInput _input;
        private CharacterPlayerConfig _characterPlayerConfig;

        public void Construct(IInput input, CharacterPlayerConfig characterPlayerConfig)
        {
            Physics2D.gravity = new Vector2(0, _gravity);

            _characterPlayerConfig = characterPlayerConfig;
            _input = input;
            _arrowDirectionMoveView.Construct(input, characterPlayerConfig);

            _input.HasAnyInput
                .Where(hasAnyInput => hasAnyInput && _input.LastFrameHasAnyInput == false)
                .Subscribe(OnStartInput)
                .AddTo(_lifeCycleDisposable);

            _input.HasAnyInput
                .Where(hasAnyInput => hasAnyInput == false && _input.LastFrameHasAnyInput == true)
                .Subscribe(OnEndInput)
                .AddTo(_lifeCycleDisposable);
        }

        private void OnDestroy()
        {
            _lifeCycleDisposable.Dispose();
        }

        private void OnStartInput(bool _)
        {
            _startInputTime = Time.time;
        }

        private void OnEndInput(bool _)
        {
            var elapsedTime = Time.time - _startInputTime;
            var currentPower = Mathf.Clamp01(elapsedTime / _characterPlayerConfig.DurationToMaxPower);

            Vector2 releaseDirection = Vector2.up;

            _rigidbody.AddForce(releaseDirection * (currentPower * _maxPushForce), ForceMode2D.Impulse);
            _rigidbody.AddTorque(_rotationForce, ForceMode2D.Impulse);
        }


        // - замедление времени
        // - восстановление 
        // - визуал драг-анд-дроп указателя силы и направления
        // - input с драг-анд-дроп 
        // - передача импульса на движение персонажа
        // - обработка ввсяких столкновений персонажем для анимаций
        // - обработка анимацией для старта полёта
        //  сделай в начале шарик на экране, нажимаешь на него, и он оттягивается в сторону. Это пока всё
    }
}