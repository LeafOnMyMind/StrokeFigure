namespace StrokeFigure.Input {
    internal abstract class InputSource { }

    internal abstract class InputSource<EmittedInputEvent> : InputSource where EmittedInputEvent : InputEvent {
        private readonly InputEventQueue queue;

        protected InputSource(InputEventQueue queue) {
            this.queue = queue;
        }

        protected void Emit(EmittedInputEvent inputEvent) {
            this.queue.Enqueue(inputEvent);
        }
    }

}
