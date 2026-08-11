using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class ScalingVariance
    {
        public float start;
        public float variance;
        public float minValue;
        public float scaling;

        public ScalingVariance(Settings settings, string name)
        {
            start = settings.Get<float>(name + nameof(start));
            variance = settings.Get<float>(name + nameof(variance));
            minValue = settings.Get<float>(name + nameof(minValue));
            scaling = settings.Get<float>(name + nameof(scaling));
        }

        public float Evaluate()
            => Mathf.Max(Random.Range(-variance, variance) + start + Time.time * scaling, minValue);
    }
}
