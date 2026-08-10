using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Burnt : StationState
    {
        public Material fluidMat;
        public Material swirlMat;
        public MeshRenderer fluid;
        public MeshRenderer swirl;
        public Item item;

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
            return item;
        }
    }
}
