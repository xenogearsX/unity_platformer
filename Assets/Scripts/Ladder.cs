using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D floor;

    
    // Start when is find
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        // si le joueur est poche de l echelle et si le joueur appuis sur E
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            // descendre de l'echelle
            playerMovement.isClimbing = false;
            floor.isTrigger = false;
            return;
        }
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            floor.isTrigger = true;
        }
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
            playerMovement.isClimbing = false;
            floor.isTrigger = false;
        }
    }

}
