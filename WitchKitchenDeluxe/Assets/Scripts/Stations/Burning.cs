using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Burning : StationState
    {
        public GameObject fluid;
        public float burnWait;
        public Item item;
        private float timer;

        public override void Enter()
        {
            fluid.SetActive(true);
            timer = 0f;
        }

        public override Item Interact(Item input)
        {
            if (input != null)
                return input;

            OnReset?.Invoke();
            return item;
        }

        public override void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= burnWait)
                OnYield?.Invoke();
        }
    }
}
