using UnityEngine;
using System;

namespace WitchKitchenDeluxe
{
    public abstract class CookingState : MonoBehaviour
    {
        public Action OnYield;
        public Action OnReset;

        public virtual void Tick() { }
        public abstract Item Interact(Item input);
        public virtual void Enter() { }
    }
}
