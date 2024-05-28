using UnityEngine;

namespace VerletChainSystem
{
    public static class Maths
    {
        public static float Snap(float value, float target, float epsilon = 1E-5f)
        {
            if (Mathf.Abs(target - value) <= epsilon)
            {
                return target;
            }

            return value;
        }

        // From https://forum.unity.com/threads/range-mapping-function.917069/#post-6007313
        public static float Remap(float value, float valueMin, float valueMax, float targetMin, float targetMax)
        {
            float fraction = Mathf.InverseLerp(valueMin, valueMax, value);
            return Mathf.Lerp(targetMin, targetMax, fraction);
        }

        public static Vector2 GetDirection(float angle)
        {
            angle *= Mathf.Deg2Rad;
            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            x = Snap(x, 0f);
            y = Snap(y, 0f);
            return new Vector2(x, y);
        }

        // From https://stackoverflow.com/a/54130006
        public static float FlipAngleX(float angle)
        {
            angle = NormalizeAngle(angle);
            return 360f - angle;
        }

        // From https://stackoverflow.com/a/54130006
        public static float FlipAngleY(float angle)
        {
            angle = NormalizeAngle(angle);

            if (angle < 180f)
            {
                return 180f - angle;
            }
            else
            {
                return 360f - angle + 180f;
            }
        }

        // From https://stackoverflow.com/a/60576187
        public static float NormalizeAngle(float angle)
        {
            angle %= 360f;

            if (angle < 0f)
            {
                angle += 360f;
            }

            return angle;
        }

        public static float FramesToSeconds(int frames, int framerate = 60)
        {
            return frames / (float)framerate;
        }
    }
}
