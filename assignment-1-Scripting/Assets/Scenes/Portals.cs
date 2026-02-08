using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField] private Transform _portalOutLocation;

    void OnTriggerEnter2D(Collider2D ball)
    {
        if (ball.gameObject.CompareTag("Ball"))
        {
            ball.gameObject.transform.position = _portalOutLocation.position;
        }
    }
    
}
