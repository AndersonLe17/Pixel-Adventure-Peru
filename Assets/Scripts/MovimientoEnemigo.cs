using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private Transform ControladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoIzquierda;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (informacionSuelo == false)
        {
            Girar();
        }
    }
    private void Girar()
    {
        moviendoIzquierda = !moviendoIzquierda;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorSuelo.transform.position, ControladorSuelo.transform.position + Vector3.down * distancia);
    }
}
