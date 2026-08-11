using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CustomerMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 endingLookDirection = default;
        private float customerSpeed;
        private bool pointSet;
        private float tolerance;
        Vector3 point;

        private void Start()
        {
            var settings = Settings.main;
            customerSpeed = settings.Get<float>(nameof(customerSpeed));
            tolerance = settings.Get<float>(nameof(tolerance));
        }

        private void Update()
        {
            if (!pointSet)
                return;
            
            Vector3 pos = Vector3.MoveTowards(transform.position, point, customerSpeed * Time.deltaTime);
            transform.position = pos;

            if (Vector3.Distance(transform.position, point) < tolerance)
            {
                transform.rotation = Quaternion.LookRotation(endingLookDirection);
                Destroy(this);
            }
        }

        public void SetDestination(Vector3 point)
        {
            pointSet = true;
            transform.forward = (point - transform.position).normalized;
            this.point = point;
        }
    }
}
