using R = UnityEngine.Random;

namespace _Core
{
    [System.Serializable]
    public class MinMaxInt
    {
        public int min;
        public int max;

        public int Random => R.Range(min, max + 1);
    }

    [System.Serializable]
    public struct MinMaxFloat
    {
        public float min;
        public float max;

        public float Random => R.Range(min, max);
    }
}