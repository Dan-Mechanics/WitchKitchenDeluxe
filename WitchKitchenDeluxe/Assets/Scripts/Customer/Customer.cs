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
        [SerializeField] private GameObject acceptEffect = default;
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
            GameObject effect = satisfied ? happyEffect : angryEffect;
            Instantiate(effect, transform.position, effect.transform.rotation);
            OnLeave?.Invoke(this);
            Destroy(gameObject);
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
            => stack.item != null ? RegularInteract(input) : UncertainInteract(input);

        public Item RegularInteract(Item input)
        {
            if (input != stack.item)
                return input;

            Accept();
            return null;
        }

        private void Accept()
        {
            stack.count--;
            onDisplayStack?.Invoke(stack);
            Instantiate(acceptEffect, transform.position, acceptEffect.transform.rotation);
            if (stack.count <= 0)
                Leave(true);
        }

        public Item UncertainInteract(Item input)
        {
            if (input == null)
                return input;

            Accept();
            return null;
        }
    }
}