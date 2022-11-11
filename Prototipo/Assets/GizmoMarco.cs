using UnityEngine;

/// <summary>
/// Gizmo que genera un marco para la navegación en el videojuego
/// </summary>
public class GizmoMarco : MonoBehaviour
{
    [SerializeField][Range(0, 30)] public float alto;
    [SerializeField][Range(0, 50)] public float ancho;

    Color color;
    [SerializeField] private Vector3 max;
    /// <summary>
    /// Posición máxima del marco
    /// </summary>
    public Vector3 Max { get => max; }

    [SerializeField] private Vector3 min;
    /// <summary>
    /// Posición mínima del marco
    /// </summary>
    public Vector3 Min { get => min; }

    public GizmoMarco()
    {
        color = Color.yellow;

        max = new Vector3(ancho * .5f, alto * .5f, 0);
        min = new Vector3(ancho * -.5f, alto * -.5f, 0);
    }

    private void OnDrawGizmos()
    {
        /*      ancho
         *    a--------b
         *    |        | alto
         *    c--------d
         */
        Vector3 posicion = gameObject.transform.position;

        Vector3 a = new Vector3(ancho * -.5f, alto * .5f, 0) + posicion;
        Vector3 b = new Vector3(ancho * .5f, alto * .5f, 0) + posicion;
        Vector3 c = new Vector3(ancho * -.5f, alto * -.5f, 0) + posicion;
        Vector3 d = new Vector3(ancho * .5f, alto * -.5f, 0) + posicion;

        Gizmos.color = color;
        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(b, d);
        Gizmos.DrawLine(d, c);
        Gizmos.DrawLine(c, a);
    }
}
