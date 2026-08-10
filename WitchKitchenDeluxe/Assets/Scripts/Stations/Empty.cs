using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Empty : StationState
    {
        public Material fluidMat;
        public Material swirlMat;
        public Item requiredItem;
        public MeshRenderer fluid;
        public MeshRenderer swirl;

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
                OnYield?.Invoke();
                return input;
            }
            else
            {
                if (input != requiredItem)
                    return input;

                OnYield?.Invoke();
                return null;
            }
        }
    }
}
