using UnityEngine;

public class Gizmo : MonoBehaviour
{
    [SerializeField] float radio = 1f;
    [SerializeField] Color color = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(gameObject.transform.position, radio);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255 - color.r, 255 - color.g, 255 - color.b);
        Gizmos.DrawWireSphere(gameObject.transform.position, radio);
    }
}