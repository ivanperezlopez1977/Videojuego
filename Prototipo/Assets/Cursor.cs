using UnityEngine;

public class Cursor : MonoBehaviour
{
    int xTeclado;
    int yTeclado;

    [SerializeField][Range(1, 12)] float velocidadManiobra;

    [SerializeField] GameObject marco;

    GizmoMarco gizmoMarco;

    float posicionX;
    float posicionY;

    public Cursor()
    {
        velocidadManiobra = 10;

        xTeclado = 0;
        yTeclado = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        gizmoMarco = marco.GetComponent<GizmoMarco>();
    }

    // Update is called once per frame
    void Update()
    {
        EntradasTeclado();

        posicionX += xTeclado * velocidadManiobra * Time.deltaTime;
        posicionY += yTeclado * velocidadManiobra * Time.deltaTime;

        posicionX = Mathf.Clamp(posicionX, gizmoMarco.Min.x, gizmoMarco.Max.x);
        posicionY = Mathf.Clamp(posicionY, gizmoMarco.Min.y, gizmoMarco.Max.y);

        gameObject.transform.position = new Vector3(posicionX, posicionY, 0);
    }

    /// <summary>
    /// Captura las pulsaciones del teclado
    /// </summary>
    private void EntradasTeclado()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yTeclado = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            yTeclado = -1;
        }
        else
        {
            yTeclado = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xTeclado = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            xTeclado = 1;
        }
        else
        {
            xTeclado = 0;
        }

        xTeclado = (int)Input.GetAxisRaw("Horizontal");
        yTeclado = (int)Input.GetAxisRaw("Vertical");

        Debug.Log("x: " + xTeclado);
        Debug.Log("y: " + yTeclado);
    }
}
