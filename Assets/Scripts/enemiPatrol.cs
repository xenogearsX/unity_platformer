using UnityEngine;

public class enemiPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer chicken;
    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
        {
            Vector3 dir = target.position - transform.position;
            //
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            //si l ennemi est poche de son point d arriver 0.3f et la distance avant le point d arriver
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                // le % est pour recupere le reste de la division
                destPoint = (destPoint + 1) % waypoints.Length;
                target = waypoints[destPoint];
            chicken.flipX = !chicken.flipX;
            }
        }
}