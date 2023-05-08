namespace LightProfiles
{
    internal static class Math
    {
        public static float Lerp(float a, float b, float t) => a + (b - a) * t;

        public static float InverseLerp(float a, float b, float v) => (v - a) / (b - a);
    }
}
