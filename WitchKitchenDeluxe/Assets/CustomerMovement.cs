using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CustomerMovement : MonoBehaviour
    {
        private float customerSpeed;
        private bool pointSet;
        Vector3 point;

        private void Start()
        {
            var easySettings = EasySettings.Current;
            customerSpeed = easySettings.Get<float>(nameof(customerSpeed));
        }

        private void Update()
        {
            if (!pointSet)
                return;
            
            Vector3 pos = Vector3.MoveTowards(transform.position, point, customerSpeed * Time.deltaTime);
            transform.position = pos;
        }

        public void SetPoint(Vector3 point)
        {
            pointSet = true;
            transform.forward = (point - transform.position).normalized;
            this.point = point;
        }
    }
}
