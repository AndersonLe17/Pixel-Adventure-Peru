using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiePlayer : MonoBehaviour
{
    [SerializeField] float velocidad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
		transform.Translate(
			horizontal*velocidad*Time.deltaTime, 0, 0
		);
		
		float vertical = Input.GetAxis("Vertical");
		transform.Translate(0,
			vertical*velocidad*Time.deltaTime, 0
		);
    }
}
