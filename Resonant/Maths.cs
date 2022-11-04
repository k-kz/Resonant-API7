﻿using System;
using System.Numerics;

namespace Resonant
{
    internal static class Maths
    {
        static internal float PI = (float)Math.PI;
        static internal float TAU = PI * 2f;
        private static readonly int CIRCLE_SEGMENTS = 180;

        // epsilon error value when comparing radian floats
        static internal float Epsilon = PI * 0.01f;

        static internal float Radians(float degrees) => PI * degrees / 180.0f;

        static internal bool BetweenAngles(float test, float start, float end)
        {
            // check if the angle between START and TEST is between 0 and the angle between START and END
            float toEnd = NormalizeRadians(end - start);
            float toTest = NormalizeRadians(test - start);

            return toTest > 0 && toTest < toEnd;
        }

        static private float NormalizeRadians(float radians) => (radians + TAU) % TAU;

        static internal float DistanceXZ(Vector3 a, Vector3 b)
        {
            float dx = b.X - a.X;
            float dz = b.Z - a.Z;
            return (float)Math.Sqrt(dx * dx + dz * dz);
        }

        static internal float AngleXZ(Vector3 a, Vector3 b) => (float)Math.Atan2(b.X - a.X, b.Z - a.Z);

        // how many segments to split an arc up into when rendering
        static internal int ArcSegments(float startRads, float endRads) => (int)(Math.Abs(endRads - startRads) * (CIRCLE_SEGMENTS / TAU)) + 1;
    }
}
