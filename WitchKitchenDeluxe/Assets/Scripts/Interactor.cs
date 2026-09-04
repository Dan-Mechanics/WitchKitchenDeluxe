using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private Transform interactPoint = default;
        [SerializeField] private LayerMask mask = default;
        private ItemHolder itemHolder;
        private float interactRadius;
        private List<IInteractable> interactables;
        private IPlayerInput input;

        private void Awake()
        {
            interactables = new List<IInteractable>();
            input = GetComponent<IPlayerInput>();
            itemHolder = GetComponent<ItemHolder>();
        }

        private void Start()
        {
            var settings = Settings.Current;
            interactRadius = settings.Get<float>(nameof(interactRadius));
         //   interactMask = LayerMask.NameToLayer(settings.Get<string>(nameof(interactMask)));
        }

        private void Update()
        {
            if (input.InteractWasPressed())
                Interact();
        }

        private void Interact()
        {
            Collider[] colliders = Physics.OverlapSphere(interactPoint.position, interactRadius, mask, QueryTriggerInteraction.Ignore);

            interactables.Clear();
            for (int i = 0; i < colliders.Length; i++)
            {
                IInteractable interactable = colliders[i].GetComponent<IInteractable>();
                if (interactable != null)
                    interactables.Add(interactable);
            }

            IInteractable closest = interactables.OrderBy(x => Vector3.Distance(x.GetPosition(), transform.position)).FirstOrDefault();
            if (closest != null)
                itemHolder.SetItem(closest.Interact(itemHolder.GetItem()));
        }
    }
}
