using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Done : CookingState
    {
        [SerializeField] private GameObject fluid = default;
        [SerializeField] private Item item = default;

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
