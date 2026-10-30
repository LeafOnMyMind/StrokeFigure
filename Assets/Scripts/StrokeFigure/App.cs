namespace StrokeFigure {
    internal sealed class App {
        private readonly InputEventQueue inputEvents = new InputEventQueue();
        internal InputEventQueue InputEvents {
            get {
                return this.inputEvents;
            }
        }

        private readonly ModeRegistry modes = new ModeRegistry();

        private readonly EffectQueue effects = new EffectQueue();

        private Mode currentMode;

        private Mode returnMode;

        private readonly AppState currentState = new AppState();
        internal AppState CurrentState {
            get {
                return this.currentState;
            }
        }

        private EffectQueue CreateStartEffects() {
            EffectQueue startEffects = new EffectQueue();
            startEffects.Enqueue(new TransitionTo<Idle>());
            return startEffects;
        }

        internal void Start() {
            EffectQueue startEffects = this.CreateStartEffects();
            while (startEffects.TryDequeue(out Effect effect)) {
                effect.ApplyTo(this);
            }
        }

        internal void Update() {
            if (this.currentMode is null) return;

            while (this.inputEvents.TryDequeue(out InputEvent inputEvent)) {
                inputEvent.DispatchTo(this.currentMode, this.currentState, this.effects);
                while (this.effects.TryDequeue(out Effect effect)) {
                    effect.ApplyTo(this);
                }
            }
        }

        internal void TransitionTo<NextMode>() where NextMode : Mode, new() {
            this.currentMode = this.modes.Get<NextMode>();

            if (this.currentMode is not Quasimode) {
                this.returnMode = this.currentMode;
            }
        }

        internal void ReturnFromQuasimode() {
            if (this.currentMode is not Quasimode) {
                string current = this.currentMode?.GetType().Name ?? "no mode";
                UnityEngine.Debug.LogWarning(
                    $"ReturnFromQuasimode was applied in {current}, " +
                    "which is not a quasimode; the mode is unchanged."
                );
                return;
            }

            this.currentMode = this.returnMode;
        }
    }
}
