using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] Transform cursor;
    [SerializeField][Range(1, 5)] float aceleracion;
    [SerializeField] float giroGrados;
    [SerializeField] int vida = 100;
    [SerializeReference] GameObject marcador;

    private void Start()
    {
        marcador.GetComponent<TextMesh>().text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cursor.transform.position, aceleracion * Time.deltaTime);

        Vector3 magnitud = gameObject.transform.position - cursor.transform.position;

        Quaternion ladeo = Quaternion.AngleAxis(giroGrados * magnitud.x, new Vector3(0, 0, 1));
        Quaternion deriva = Quaternion.AngleAxis(giroGrados * magnitud.x * .5f, new Vector3(0, -1, 0));
        Quaternion inclinacion = Quaternion.AngleAxis(giroGrados * magnitud.y * .5f, new Vector3(1, 0, 0));

        gameObject.transform.rotation = deriva * inclinacion * ladeo;
    }

    private void OnTriggerEnter(Collider other)
    {
        vida -= other.gameObject.GetComponent<Asteroide>().HacerDanno();
        marcador.GetComponent<TextMesh>().text = vida.ToString();

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
