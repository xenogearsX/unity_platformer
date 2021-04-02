using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
        public int maxHealth = 100;
        public int currentHealth;

        public HealthBar healthBar;

        public static PlayerHealth instance;

        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }


    void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(20);
            }
        }

    void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                Die();
                return;
            }
        }
    public void Die()
    {
        Debug.Log("Le joueur est éliminé");
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Die");
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
    }
}
