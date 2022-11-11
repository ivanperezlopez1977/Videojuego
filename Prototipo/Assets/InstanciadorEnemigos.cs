using UnityEngine;

public class InstanciadorEnemigos : MonoBehaviour
{
    [SerializeField] float intervalo;
    [SerializeField] GameObject enemigoFuente;

    float contador;

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if (contador > intervalo)
        {
            contador = 0;

            _ = Instantiate(enemigoFuente, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 25), Quaternion.identity);
        }
    }
}
