using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // la condition va chercher le tag associé au player
        if (collision.CompareTag("Player"))
        {
            // va supprimer l ensemble des fichier present dans enemi
            Destroy(objectToDestroy);
        }
    }
    
}
