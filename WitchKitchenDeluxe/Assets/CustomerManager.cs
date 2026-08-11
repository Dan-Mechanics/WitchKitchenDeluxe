using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CustomerManager : MonoBehaviour
    {
        [SerializeField] private GameObject customerPrefab = default;
        [SerializeField] private Transform platformHolder = default;
        [SerializeField] private Transform spawnpoint = default;
        [SerializeField] private Item[] items = default;
        private ScalingVariance patience;
        private ScalingVariance interval;
        private int maxCustomerSpawnCount;
        private int maxItemsCount;
        private Slot[] slots;

        private void Awake()
        {
            slots = new Slot[platformHolder.childCount];
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].platform = platformHolder.GetChild(i);
            }

            var settings = Settings.main;
            maxItemsCount = settings.Get<int>(nameof(maxItemsCount));
            maxCustomerSpawnCount = settings.Get<int>(nameof(maxCustomerSpawnCount));
            patience = new ScalingVariance(settings, nameof(patience));
            interval = new ScalingVariance(settings, nameof(interval));
        }

        private void Start()
            => Invoke(nameof(SpawnCustomerDelayed), interval.Evaluate());

        private void SpawnCustomerDelayed()
        {
            for (int i = 0; i < maxCustomerSpawnCount; i++)
            {
                SpawnCustomer();
            }

            CancelInvoke(nameof(SpawnCustomerDelayed));
            Invoke(nameof(SpawnCustomerDelayed), interval.Evaluate());
        }

        private void SpawnCustomer()
        {
            int index = 0;
            Transform platform = null;
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].customer == null)
                {
                    platform = slots[i].platform;
                    index = i;
                }
            }

            if (platform == null)
                return;

            GameObject go = Instantiate(customerPrefab, spawnpoint.position, Quaternion.identity);

            Vector3 point = platform.position;
            point.y = spawnpoint.position.y;
            go.GetComponent<CustomerMovement>().SetDestination(point);

            var customer = go.GetComponent<Customer>();
            var profile = GetCustomerProfile();
            customer.Initialize(profile.Item1, profile.Item2);
            customer.OnLeave += OnCustomerLEave;
            slots[index].customer = customer;
        }

        private void OnCustomerLEave(Customer customer)
        {
            customer.OnLeave -= OnCustomerLEave;
            for (int i = 0; i < slots.Length; i++)
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
                item = items[Random.Range(0, items.Length)],
                count = Random.Range(1, maxItemsCount + 1)
            };

            return (patience, stack);
        }

        private struct Slot
        {
            public Customer customer;
            public Transform platform;
        }
    }
}
