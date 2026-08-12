using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Empty : CookingState
    {
        [SerializeField] private Material fluidMat = default;
        [SerializeField] private Material swirlMat = default;
        [SerializeField] private Item requiredItem = default;
        [SerializeField] private MeshRenderer fluid = default;
        [SerializeField] private MeshRenderer swirl = default;

        public override void Enter()
        {
            fluid.material = fluidMat;
            swirl.material = swirlMat;
            swirl.gameObject.SetActive(false);
            fluid.gameObject.SetActive(false);
        }

        public override Item Interact(Item input)
        {
            if (requiredItem == null)
            {
                // THERE IS NO ITEM REQUIRED, 
                // EVERYTHING IS ACCEPTED.
                OnYield?.Invoke();
                return input;
            }
            else
            {
                if (input != requiredItem)
                    return input;

                // INPUT ITEM MUST MATCH.
                OnYield?.Invoke();
                return null;
            }
        }
    }
}
