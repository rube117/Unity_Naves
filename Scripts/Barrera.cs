using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour {
    // Ciclo for infinito
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruye lo que choca con la barrera, un collider con is trigger habilitado
        Destroy(collision.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
