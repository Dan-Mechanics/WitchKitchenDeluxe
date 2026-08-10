using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Working : StationState
    {
        public float wait;
        public GameObject swirl;
        private float timer;

        public override void Enter()
        {
            timer = 0f;
            swirl.SetActive(true);
        }

        public override Item Interact(Item input)
            => input;

        public override void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= wait)
                OnYield?.Invoke();
        }

    }
}
