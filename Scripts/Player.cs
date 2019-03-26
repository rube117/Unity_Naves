using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declaramos la rapidez de la nave
    private float rapidez = 10.0f;
    
    // Variables para no salir de la pantalla
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Objetos de juego para Unity
    public GameObject laser;

    private Coroutine corrutina;

    // Use this for initialization
    void Start ()
    {
        // Invocamos la Main Camera para indicar los límites de los atributos anteriores
        Camera camara = Camera.main;

        // Creamos los límites con esa cámara
        xMin = camara.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 1; // Punto de pantalla al punto de vista
        xMax = camara.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 1;
        yMin = camara.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 1;
        yMax = camara.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1;

        // Probando Disparar
        // StartCoroutine(DispararContinuamente());
    }
	
	// Update is called once per frame
	void Update ()
    {
        Mover();
        Disparar();
	}

    // Métodos para el jugador
    private void Mover()
    {
        // Movimiento horizontal
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * rapidez;
        // Aplicamos el límite con la clase Mathf
        float nuevaX = Mathf.Clamp(transform.position.x + dx,xMin,xMax);

        // Movimiento vertical
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * rapidez;
        // Aplicamos el límite con la clase Mathf
        float nuevaY = Mathf.Clamp(transform.position.y + dy, yMin, yMax);

        transform.position = new Vector2(nuevaX, nuevaY);
    }
    private void Disparar()
    {
        // Click izquierdo del mouse Fire1.
        // Barra espaciadora Jump.
        if(Input.GetButtonDown("Jump"))
        {
            corrutina=StartCoroutine(DispararContinuamente());
        }
        // Detener disparos
        if(Input.GetButtonUp("Jump"))
        {
            StopCoroutine(corrutina);
        }
    }
    // Seguir disparando
    private IEnumerator DispararContinuamente()
    {
        while(true)
        {
            // Aquí vamos a crear con código un nuevo prefab tipo laser
            // Crear un objeto de tipo laser
            // Instanciar(objeto,posicion,perfecta_alineacion)
            GameObject ll = Instantiate(laser, transform.position, Quaternion.identity);
            // Vamos a invocar la componente Rigidbody de nuestro prefab
            ll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    /* Dispara continuamente
     * private void Disparar()
    {
        // Click izquierdo del mouse.
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(DispararContinuamente());
        }
    }
     * */
}
