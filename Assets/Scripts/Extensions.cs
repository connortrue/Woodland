using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic) {
            return false;
        }

        float radius = 0.3f;
        float distance = 1.7f;

        // Debug.DrawRay(rigidbody.position, direction * distance, Color.green); // Draw the raycast for visualization
        // Debug.Log("Raycast Origin: " + rigidbody.position);
        // Debug.Log("Raycast Direction: " + direction);
        // Debug.Log("Raycast Distance: " + distance);

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }
}
