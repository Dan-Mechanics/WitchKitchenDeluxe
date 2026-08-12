using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Working : CookingState
    {
        [SerializeField] private GameObject swirl = default;
        [SerializeField] private Item item = default;
        private float timer;
        private float wait;

        private void Start()
            => wait = Settings.main.Get<float>(item.name + nameof(wait));

        public override void Enter()
        {
            timer = 0f;
            swirl.SetActive(true);
        }

        /// <summary>
        /// Do nothing.
        /// </summary>
        public override Item Interact(Item input)
            => input;

        public override void Tick()
        {
            timer += Time.fixedDeltaTime;
            if (timer >= wait)
                OnYield?.Invoke();
        }
    }
}
