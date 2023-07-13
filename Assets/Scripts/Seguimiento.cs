using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public GameObject enemigo, player;
    private Vector2 distancia;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = enemigo.transform.position - player.transform.position;

        if (distancia.magnitude < 1.4)
        {
            enemigo.transform.position = Vector2.Lerp(enemigo.transform.position, player.transform.position, 0.0026f);
        }
    }
}
