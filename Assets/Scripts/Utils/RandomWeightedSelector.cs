using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public class RandomWeightedSelector<T>
    {
        private List<T> items = new List<T>();
        private List<float> weights = new List<float>();

        private float totalWeight = 0.0f;

        public void AddItem(T item, float weight)
        {
            items.Add(item);
            weights.Add(weight);

            totalWeight += weight;
        }

        public T GetRandomItem()
        {
            float randomWeight = Random.Range(0.0f, totalWeight);

            float sum = 0.0f;

            for (int i = 0; i < items.Count; i++)
            {
                sum += weights[i];

                if (sum >= randomWeight)
                {
                    return items[i];
                }
            }

            return default;
        }
    }
}