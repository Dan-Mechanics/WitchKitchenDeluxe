using System;
using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CookingStation : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item item = default;
        [SerializeField] private Item burntItem = default;
        [SerializeField] private MeshRenderer swirl = default;
        [SerializeField] private MeshRenderer fluid = default;
        [SerializeField] private Material burntSwirl = default;
        [SerializeField] private Material burntFluid = default;
        [SerializeField] private Material swirlMat = default;
        [SerializeField] private Material fluidMat = default;
        [SerializeField] private Item requiredItem = default;
        private StationState[] states;
        private float burnWait;
        private float wait;
        private int index;

        private void Awake()
        {
            burnWait = Settings.Current.Get<float>(item.name + nameof(burnWait));
            wait = Settings.Current.Get<float>(item.name + nameof(wait));
            states = new StationState[] 
            { 
                new Empty() { requiredItem = requiredItem, fluid = fluid, swirl = swirl, swirlMat = swirlMat, fluidMat = fluidMat },
                new Working() { swirl = swirl.gameObject, wait = wait },
                new Burning() { fluid = fluid.gameObject, item = item, burnWait = burnWait },
                new Burnt() { item = burntItem, fluid = fluid, swirl = swirl, swirlMat = burntSwirl, fluidMat = burntFluid }
            };

            for (int i = 0; i < states.Length; i++)
            {
                states[i].OnYield += OnStateYield;
                states[i].OnReset += OnStateReset;
            }
        }

        private void Start()
            => OnStateReset();

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
            => states[index].FixedUpdate();
    }
}
