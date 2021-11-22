using UnityEngine;

namespace Game.Extensions
{
    public static class VectorExtension
    {
        /// <summary>
        /// This method returns the normalized vector's most prominent component.
        /// The value of the vector's component is rounded to 1.
        /// </summary>
        /// <example>
        /// If the most prominent component is on horizontal axis and the value is positive, it'll return (1,0) Vector (Vector2.right).
        /// </example>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 GetProminentVectorComponent(this Vector2 vector)
        {
            vector = vector.normalized;
            if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            {
                return vector.x > 0 ? Vector2.right : Vector2.left;
            }
            else
            {
                return vector.y > 0 ? Vector2.up : Vector2.down;
            }
        }
    }
}