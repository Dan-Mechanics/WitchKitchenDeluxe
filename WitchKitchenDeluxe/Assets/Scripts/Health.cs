using UnityEngine;
using UnityEngine.Events;

namespace WitchKitchenDeluxe
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent<int> onHealthChanged = default;
        [SerializeField] private UnityEvent onGameOver = default;
        private int maxHealth;
        private int health;

        private void Start()
        {
            var settings = Settings.Current;
            maxHealth = settings.Get<int>(nameof(maxHealth));
            health = maxHealth;
            onHealthChanged?.Invoke(health);
            
            EventManager.AddListener(Occasion.AngryCustomer, Damage);
        }

        private void Damage()
        {
            health--;
            health = Mathf.Clamp(health, 0, maxHealth);
            onHealthChanged?.Invoke(health);
            if (health <= 0)
                onGameOver?.Invoke();
        }

        private void OnDestroy()
            => EventManager.RemoveListener(Occasion.AngryCustomer, Damage);

    }
}
