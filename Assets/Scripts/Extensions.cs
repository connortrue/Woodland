using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic) {
            return false;
        }

        float radius = 0.25f;
        float distance = 1.5f;

        // Debug.DrawRay(rigidbody.position, direction * distance, Color.green); // Draw the raycast for visualization
        // Debug.Log("Raycast Origin: " + rigidbody.position);
        // Debug.Log("Raycast Direction: " + direction);
        // Debug.Log("Raycast Distance: " + distance);

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }
}
