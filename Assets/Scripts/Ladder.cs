using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // box de colision avec l echelle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si le tag player rentre dans la box de colision
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    // une fois sortie de la box echelle
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

}
