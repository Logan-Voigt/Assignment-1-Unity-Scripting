using UnityEngine;


public class ShowGizmo : MonoBehaviour
{

    [SerializeField] private Color _gizmoColor = Color.rebeccaPurple;
    [SerializeField] private float _radius = 0.5f;
    void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}

