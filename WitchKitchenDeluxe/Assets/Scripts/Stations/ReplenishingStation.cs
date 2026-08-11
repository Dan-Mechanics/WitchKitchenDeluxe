using System;
using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class ReplenishingStation : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item item = default;
        [SerializeField] private MeshRenderer swirl = default;
        [SerializeField] private MeshRenderer fluid = default;
        [SerializeField] private Material swirlMat = default;
        [SerializeField] private Material fluidMat = default;
        private StationState[] states;
        private float wait;
        private int index;

        private void Awake()
        {
            wait = Settings.main.Get<float>(item.name + nameof(wait));
            states = new StationState[] 
            { 
                new Empty() { fluid = fluid, swirl = swirl, swirlMat = swirlMat, fluidMat = fluidMat },
                new Working() { swirl = swirl.gameObject, wait = wait,  },
                new Done() { fluid = fluid.gameObject, item = item }
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
