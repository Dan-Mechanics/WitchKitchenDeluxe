using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CookingStation : MonoBehaviour, IInteractable
    {
        [SerializeField] private CookingState[] states = default;
        private int index;

        private void Start()
        {
            for (int i = 0; i < states.Length; i++)
            {
                states[i].OnYield += OnStateYield;
                states[i].OnReset += OnStateReset;
            }

            OnStateReset();
        }

        public Vector3 GetPosition()
            => transform.position;

        public void OnStateYield()
        {
            index++;
            if (index >= states.Length)
                index = 0;

            states[index].Enter();
        }

        public void OnStateReset()
        {
            index = 0;
            states[index].Enter();
        }

        public Item Interact(Item input)
            => states[index].Interact(input);

        private void FixedUpdate()
            => states[index].Tick();
    }
}
