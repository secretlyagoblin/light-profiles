using System;

namespace LightProfiles
{

    public readonly struct ProfilePoint
    {
        public ProfilePoint(float percentageX, float absoluteY)
        {
            if(percentageX < 0 || percentageX > 1)
                throw new Exception("Profile point x should be normalised between 0-1");

            PercentageX = percentageX;
            AbsoluteY = absoluteY;
        }

        public float PercentageX { get; }
        public float AbsoluteY { get; }   

        
    }
}
