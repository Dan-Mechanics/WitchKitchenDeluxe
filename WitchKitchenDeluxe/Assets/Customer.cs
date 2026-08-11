using System;
using UnityEngine;
using UnityEngine.Events;

namespace WitchKitchenDeluxe
{
    public class Customer : MonoBehaviour, IInteractable
    {
        public event Action<Customer> OnLeave;
        [SerializeField] private GameObject happyEffect = default;
        [SerializeField] private GameObject angryEffect = default;
        [SerializeField] private UnityEvent<float> onDisplayTimer = default;
        [SerializeField] private UnityEvent<Stack> onDisplayStack = default;
        private float patience;
        private Stack stack;
        private float timer;

        private void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;
            timer = Mathf.Clamp(timer, 0f, patience);
            onDisplayTimer?.Invoke(timer / patience);
            if (timer >= patience)
            {
                EventManager.RaiseEvent(Occasion.AngryCustomer);
                Leave(false);
            }
        }

        private void Leave(bool satisfied)
        {
            timer = 0f;
            Instantiate(satisfied ? happyEffect : angryEffect, transform.position, happyEffect.transform.rotation);
            OnLeave?.Invoke(this);
            Leave(gameObject);
        }
        
        public void Initialize(float patience, Stack stack)
        {
            this.patience = patience;
            this.stack = stack;
            onDisplayStack?.Invoke(stack);
        }

        public Vector3 GetPosition()
            => transform.position;

        public Item Interact(Item input)
        {
            if (input != stack.item)
                return input;

            stack.count--;
            onDisplayStack?.Invoke(stack);
            if (stack.count <= 0)
                Leave(true);

            return null;
        }
    }
}