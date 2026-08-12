using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Burning : CookingState
    {
        [SerializeField] private GameObject fluid = default;
        [SerializeField] private Item item = default;
        private float burnWait;
        private float timer;

        private void Start()
            => burnWait = Settings.main.Get<float>(item.name + nameof(burnWait));

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

        public override void Tick()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= burnWait)
                OnYield?.Invoke();
        }
    }
}
