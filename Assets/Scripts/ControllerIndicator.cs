using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerIndicator : MonoBehaviour
{
    public Text txtLifes;
    public int lifes = 3;
    public Text txtFruits;
    public int fruits = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtLifes.text = lifes.ToString();
        txtFruits.text = fruits.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Item"))
        {
            fruits += 1;
            txtFruits.text = fruits.ToString();
            Debug.Log(gameObject.tag);
        }
        if (other.gameObject.CompareTag("Bat"))
        {
            lifes -= 1;

            //evaluateLife
            if (lifes <= 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                txtFruits.text = fruits.ToString();
            }
        }
    }

}
