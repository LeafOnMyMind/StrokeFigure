namespace StrokeFigure {
    internal abstract record InputEvent {
        internal abstract void DispatchTo(
            InputHandler recipient, AppState state, EffectQueue effects
        );
    }

    internal abstract record InputEvent<Self> : InputEvent where Self : InputEvent<Self> {
        internal sealed override void DispatchTo(
            InputHandler recipient, AppState state, EffectQueue effects
        ) {
            if (recipient is InputHandler<Self> handler) {
                handler.Handle(this as Self, state, effects);
            } else {
                UnityEngine.Debug.LogWarning(
                    $"{recipient.GetType().Name} does not implement " +
                    $"InputHandler<{typeof(Self).Name}>. " +
                    "The input event will be ignored."
                );
            }
        }
    }
}
