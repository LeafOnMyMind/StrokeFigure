using StrokeFigure.Input;
using StrokeFigure.Logging;
using StrokeFigure.State;
using UnityEngine;

namespace StrokeFigure.InteractiveApp {
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
        internal Mode CurrentMode {
            get {
                return this.currentMode;
            }
        }


        private Mode returnMode;
        internal Mode ReturnMode {
            get {
                return this.returnMode;
            }
        }

        private readonly AppState currentState = new AppState();
        internal AppState CurrentState {
            get {
                return this.currentState;
            }
        }

        private readonly AppLogger logger = new AppLogger();

        internal App(EffectQueue startEffects) {
            while (startEffects.TryDequeue(out Effect effect)) {
                this.logger.Append(Time.realtimeSinceStartupAsDouble,
                this.currentMode?.GetType().Name ?? "none", effect);
                effect.ApplyTo(this);
            }
        }

        internal void Update() {
            if (this.currentMode is null) return;

            while (this.inputEvents.TryDequeue(out InputEvent inputEvent)) {
                inputEvent.DispatchTo(this.currentMode, this.currentState, this.effects);
                while (this.effects.TryDequeue(out Effect effect)) {
                    this.logger.Append(Time.realtimeSinceStartupAsDouble,
                        this.currentMode.GetType().Name, effect);
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
