using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private Transform selection = default;
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
            var settings = Settings.main;
            float tolerance = settings.Get<float>(nameof(tolerance));
            interactRadius = settings.Get<float>(nameof(interactRadius));
            selection.localScale = new Vector3(interactRadius * 2f, tolerance, interactRadius * 2f);
            mask = LayerMask.GetMask(settings.Get<string>(nameof(mask)));
        }

        private void Update()
        {
            if (input.InteractWasPressed())
                Interact();
        }

        private void Interact()
        {
            Collider[] colliders = Physics.OverlapSphere(selection.position, interactRadius, mask, QueryTriggerInteraction.Ignore);
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
