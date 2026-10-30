using System.Collections.Concurrent;

namespace StrokeFigure.Input {
    internal sealed class InputEventQueue {
        private readonly ConcurrentQueue<InputEvent> events = new ConcurrentQueue<InputEvent>();

        public InputEventQueue() { }

        public void Enqueue(InputEvent newEvent) {
            this.events.Enqueue(newEvent);
        }

        internal bool TryDequeue(out InputEvent oldestEvent) {
            return this.events.TryDequeue(out oldestEvent);
        }
    }
}
