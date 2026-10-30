using StrokeFigure.InteractiveApp;
using StrokeFigure.State;

namespace StrokeFigure.Input {
    internal interface InputHandler { }

    internal interface InputHandler<in HandledInputEvent> : InputHandler
        where HandledInputEvent : InputEvent {
        void Handle(HandledInputEvent inputEvent, AppState state, EffectQueue effects);
    }
}
