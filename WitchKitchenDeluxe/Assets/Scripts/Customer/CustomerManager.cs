using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CustomerManager : MonoBehaviour
    {
        [SerializeField] private GameObject customerPrefab = default;
        [SerializeField] private Transform platformHolder = default;
        [SerializeField] private Transform spawnpoint = default;
        [SerializeField] private Item[] menu = default;
        private ScalingVariance patience;
        private ScalingVariance interval;
        private int maxCustomerSpawnCount;
        private float startingDelay;
        private int menuProgression;
        private int maxItemsCount;
        private List<Slot> slots;

        private void Awake()
        {
            slots = new List<Slot>();
            for (int i = 0; i < platformHolder.childCount; i++)
            {
                slots.Add(new Slot() { index = i, platform = platformHolder.GetChild(i) });
            }

            var settings = Settings.Current;
            maxItemsCount = settings.Get<int>(nameof(maxItemsCount));
            maxCustomerSpawnCount = settings.Get<int>(nameof(maxCustomerSpawnCount));
            startingDelay = settings.Get<float>(nameof(startingDelay));
            patience = new ScalingVariance(settings, nameof(patience));
            interval = new ScalingVariance(settings, nameof(interval));
        }

        private void Start()
            => Invoke(nameof(SpawnCustomerDelayed), startingDelay);

        private void SpawnCustomerDelayed()
        {
            menuProgression++;
            if (menuProgression >= menu.Length)
                menuProgression = menu.Length - 1;

            for (int i = 0; i < Random.Range(1, maxCustomerSpawnCount); i++)
            {
                SpawnCustomer();
            }

            CancelInvoke(nameof(SpawnCustomerDelayed));
            Invoke(nameof(SpawnCustomerDelayed), interval.Evaluate());
        }

        private void SpawnCustomer()
        {
            if (!TryGetPlatform(out Transform platform, out int index))
                return;

            GameObject go = Instantiate(customerPrefab, spawnpoint.position, Quaternion.identity);

            Vector3 point = platform.position;
            point.y = spawnpoint.position.y;
            go.GetComponent<CustomerMovement>().SetDestination(point);

            var customer = go.GetComponent<Customer>();
            var profile = GetCustomerProfile();
            customer.Initialize(profile.Item1, profile.Item2);
            customer.OnLeave += OnCustomerLeave;
            slots[index].customer = customer;
        }

        private bool TryGetPlatform(out Transform platform, out int index)
        {
            index = 0;
            platform = null;
            var remainder = slots.Where(x => x.customer == null).ToList();
            if (remainder.Count <= 0)
                return false;

            var slot = remainder[Random.Range(0, remainder.Count)];
            platform = slot.platform;
            index = slot.index;
            return true;
        }

        private void OnCustomerLeave(Customer customer)
        {
            customer.OnLeave -= OnCustomerLeave;
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].customer == customer)
                    slots[i].customer = null;
            }
        }

        (float, Stack) GetCustomerProfile()
        {
            float patience = this.patience.Evaluate();
            Stack stack = new Stack()
            {
                item = menu[Random.Range(0, menuProgression)],
                count = Random.Range(1, maxItemsCount + 1)
            };

            return (patience, stack);
        }

        private class Slot
        {
            public Customer customer;
            public int index;
            public Transform platform;
        }
    }
}
