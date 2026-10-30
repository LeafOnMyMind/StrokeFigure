using System.Collections.Generic;

namespace StrokeFigure {
    internal sealed class EffectQueue {
        private readonly Queue<Effect> effects = new Queue<Effect>();

        internal void Enqueue(Effect effect) {
            this.effects.Enqueue(effect);
        }

        internal bool TryDequeue(out Effect oldestEffect) {
            return this.effects.TryDequeue(out oldestEffect);
        }
    }
}
