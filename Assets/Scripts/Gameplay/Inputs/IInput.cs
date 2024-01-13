using System;
using UniRx;

namespace FlipBros.Gameplay.Inputs
{
    public interface IInput
    {
        public IReadOnlyReactiveProperty<bool> HasAnyInput { get; }
        public bool LastFrameHasAnyInput { get; }
    }
}