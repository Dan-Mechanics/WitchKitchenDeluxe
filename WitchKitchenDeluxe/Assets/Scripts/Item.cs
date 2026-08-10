using UnityEngine;

namespace WitchKitchenDeluxe
{
    [CreateAssetMenu(fileName = nameof(Item), menuName = nameof(Item))]
    public class Item : ScriptableObject
    {
        public Sprite icon;
        public GameObject graphic;
    }
}
