using SimplexNoise;
using System;
using System.Collections.Generic;

namespace LightProfiles.Interpolation
{
    public class ProfileSet
    {
        public IDictionary<string, Profile> _lookup = new Dictionary<string, Profile>();


        public double BarycentricInterpolateProfiles(WeightedBarycenter<string> weight, float sample)
        {
            var u = _lookup[weight.U];
            var v = _lookup[weight.V];
            var w = _lookup[weight.W];

            return Blerp(u.HeightAt(sample), v.HeightAt(sample), w.HeightAt(sample), weight.ABC);
        }


        private static float Blerp(float a, float b, float c, Barycenter weight)
        {
            return (float)(a * weight.A + b * weight.B + c * weight.C);
        }
    }
}
