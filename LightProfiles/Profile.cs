using System;
using System.Collections.Generic;
using System.Linq;

namespace LightProfiles
{
    public class Profile
    {
        private ProfilePoint[] _points;

        public string Name { get; }

        public IEnumerable<ProfilePoint> GetPoints() => _points.ToList();

        public Profile(string name, IEnumerable<ProfilePoint> points)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (points is null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            if (points.Count() == 0)
            {
                throw new Exception("Profile cannot be empty");
            }

            var processedPoints = points.OrderBy(x => x.PercentageX).ToList();

            if (processedPoints.First().PercentageX != 0) processedPoints
                    .Insert(0, new ProfilePoint(0, processedPoints.First().AbsoluteY));
            if (processedPoints.Last().PercentageX != 1) processedPoints
                    .Add(new ProfilePoint(1, processedPoints.Last().AbsoluteY));

            _points = processedPoints.ToArray();
            Name = name;
        }

        public float HeightAt(float percentage)
        {
            if (percentage <= 0) return _points[0].AbsoluteY;
            if (percentage >= 1) return _points[_points.Length - 1].AbsoluteY;


                for (int i = 0; i < _points.Length - 1; i++)
                {
                    var a = _points[i];
                    var b = _points[i + 1];

                    if (percentage >= a.PercentageX && percentage <= b.PercentageX)
                    {
                        var testPercentage = Math.InverseLerp(a.PercentageX, b.PercentageX, percentage);

                        return Math.Lerp(a.AbsoluteY, b.AbsoluteY, testPercentage);
                    }


                }

                throw new Exception($"Could not find height for profile '{Name}' at parameter '{percentage}'");
            }
        
    }
}
