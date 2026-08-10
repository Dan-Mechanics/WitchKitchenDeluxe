using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Done : StationState
    {
        public GameObject fluid;
        public Item item;

        public override void Enter()
            => fluid.SetActive(true);

        public override Item Interact(Item input)
        {
            if (input != null)
                return input;

            OnReset?.Invoke();
            return item;
        }
    }
}
