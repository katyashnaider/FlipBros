using System;
using UniRx;
using UnityEngine;

namespace FlipBros.Gameplay.Inputs
{
    public class DesktopAndMobileInput : IInput, IDisposable
    {
        private readonly ReactiveProperty<bool> _hasAnyInput = new ReactiveProperty<bool>();

        public IReadOnlyReactiveProperty<bool> HasAnyInput => _hasAnyInput;
        public bool LastFrameHasAnyInput { get; private set; }

        public void ThisUpdate()
        {
            var newValueHasAnyInput =
                Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.touchCount > 0;

            LastFrameHasAnyInput = HasAnyInput.Value;
            _hasAnyInput.Value = newValueHasAnyInput;
        }

        public void Dispose()
        {
            _hasAnyInput.Dispose();
        }
    }
}