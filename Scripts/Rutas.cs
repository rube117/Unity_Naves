using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rutas : MonoBehaviour {

    public List<Transform> lugares;
    int indice = 0;
    float rapidez = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = lugares[indice].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    private void Mover()
    {
        if (indice <= lugares.Count - 1)
        {
            print("Indices totales " + lugares.Count);
            var nuevaPosi = lugares[indice].transform.position;
            var mover = rapidez * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, nuevaPosi, mover);
            if (transform.position == nuevaPosi)
            {
                print("Se incrementaaaaaaaaaaaaaaa" + indice);
                indice++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
