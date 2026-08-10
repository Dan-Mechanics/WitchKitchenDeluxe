using System;

namespace WitchKitchenDeluxe
{
    public abstract class StationState
    {
        public Action OnYield;
        public Action OnReset;

        public virtual void FixedUpdate() { }
        public abstract Item Interact(Item input);
        public virtual void Enter() { }
    }
}
