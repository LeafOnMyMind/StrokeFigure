using System;
using System.Collections.Generic;

namespace StrokeFigure {
    internal sealed class ModeRegistry {
        private Dictionary<Type, Mode> modes = new Dictionary<Type, Mode>();

        internal RequestedMode Get<RequestedMode>() where RequestedMode : Mode, new() {
            if (this.modes.TryGetValue(typeof(RequestedMode), out Mode existing)) {
                return existing as RequestedMode;
            }

            RequestedMode created = new RequestedMode();
            this.modes.Add(typeof(RequestedMode), created);
            return created;
        }
    }
}
