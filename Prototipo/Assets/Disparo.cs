using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{
    [SerializeField] GameObject destelloFuente;
    [SerializeField] Transform mirilla;
    [SerializeField] Image mirillaImagen;

    Camera camera = null;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 posicionMirillaPixeles = camera.WorldToScreenPoint(mirilla.position);
        mirillaImagen.rectTransform.transform.position = posicionMirillaPixeles;

        //Rayo proyectado desde la pantalla, pasando por la mirilla
        Ray rayo = camera.ScreenPointToRay(camera.WorldToScreenPoint(mirilla.position));

        Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);

        if (Input.GetKey(KeyCode.Space))
        {
            if (Physics.Raycast(rayo, out hit))
            {
                Debug.DrawRay(camera.transform.position, rayo.direction * hit.distance, Color.red);

                GameObject destello = Instantiate(destelloFuente, hit.point, Quaternion.identity);
                Destroy(destello, .2f);
            }
            else
            {
                Debug.DrawRay(camera.transform.position, rayo.direction * 1000, Color.green);
            }
        }
    }
}
