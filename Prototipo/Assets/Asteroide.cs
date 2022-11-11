using UnityEngine;

public class Asteroide : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float velocidad;
    [SerializeField] int danno = 50;

    public int HacerDanno()
    {
        return danno;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -1) * Time.deltaTime * velocidad;
    }
}
