using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Burnt : CookingState
    {
        [SerializeField] private Material fluidMat = default;
        [SerializeField] private Material swirlMat = default;
        [SerializeField] private MeshRenderer fluid = default;
        [SerializeField] private MeshRenderer swirl = default;
        [SerializeField] private Item burntItem = default;

        public override void Enter()
        {
            fluid.material = fluidMat;
            swirl.material = swirlMat;
        }

        public override Item Interact(Item input)
        {
            if (input != null)
                return input;

            OnReset?.Invoke();
            return burntItem;
        }
    }
}
