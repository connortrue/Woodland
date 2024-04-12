using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform Player;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPositon = transform.position;
        cameraPositon.x = Mathf.Max(cameraPositon.x, Player.position.x);
        transform.position = cameraPositon;
    }
}
