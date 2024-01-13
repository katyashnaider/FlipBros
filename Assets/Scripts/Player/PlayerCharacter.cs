using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace FlipBros.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private float _maxPushForce = 20f;
        [SerializeField] private float _minDraggingDuration = 0.1f;
        [SerializeField] private float _speedScale = 2f;
        [SerializeField] private SpriteRenderer _arrowImage;

        private Vector2 _startPosition;
        private Rigidbody2D _rigidbody;


        private float _currentPushForce;
        private float _dragStartTime;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // - замедление времени
        // - восстановление 
        // - визуал драг-анд-дроп указателя силы и направления
        // - input с драг-анд-дроп 
        // - передача импульса на движение персонажа
        // - обработка ввсяких столкновений персонажем для анимаций
        // - обработка анимацией для старта полёта
        //  сделай в начале шарик на экране, нажимаешь на него, и он оттягивается в сторону. Это пока всё

        public void OnMouseDown()
        {
            _dragStartTime = Time.time;
            _rigidbody.velocity = Vector2.zero;
            _arrowImage.gameObject.SetActive(true);
        }

        public void OnMouseDrag()
        {
            float elapsedDraggingTime = Time.time - _dragStartTime;

            _currentPushForce = Mathf.Clamp01(elapsedDraggingTime / _minDraggingDuration) * _maxPushForce;

            UpdateArrowVisual();
        }

        public void OnMouseUp()
        {
            Vector2 releaseDirection = Vector2.up;

            if (_rigidbody != null)
            {
                _rigidbody.AddForce(releaseDirection * _currentPushForce, ForceMode2D.Impulse);
            }
        }

        private void UpdateArrowVisual()
        {
            var localScale = _arrowImage.transform.localScale;
            float minScale = 0.5f;
            float maxScale = 3f;
            

            _arrowImage.transform.localScale = new Vector3(Mathf.Lerp(minScale, maxScale, Mathf.Pow(_currentPushForce, _minDraggingDuration)),
                _arrowImage.transform.localScale.y, _arrowImage.transform.localScale.z);
        }

        // public void OnMouseDown()
        // {
        //     _rigidbody.velocity = Vector2.zero;
        //     _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        // }
        //
        // public void OnMouseDrag()
        // {
        //     Vector2 currentPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        //
        //     float dragDistance = Vector2.Distance(_startPosition, currentPosition);
        //     float normalizedDistance = Mathf.Clamp01(dragDistance / _minDraggingDistance);
        //
        //     _currentPushForce = Mathf.Lerp(0f, _maxPushForce, normalizedDistance);
        // }
        //
        // public void OnMouseUp()
        // {
        //     Vector2 releaseDirection = (_startPosition - (Vector2)_camera.ScreenToWorldPoint(Input.mousePosition)).normalized;
        //
        //     if (_rigidbody != null)
        //     {
        //         _rigidbody.AddForce(releaseDirection * _currentPushForce, ForceMode2D.Impulse);
        //     }
        // }
    }

    public class InputHoldAndShoot : MonoBehaviour
    {
        private float _dragStartTime;

        public event Action StartInput;
        public event Action ShutInput;

        public void OnMouseDown()
        {
            _dragStartTime = Time.time;
           // _rigidbody.velocity = Vector2.zero;
           // _arrowImage.gameObject.SetActive(true);
        }
    }
}