using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
        public int maxHealth = 100;
        public int currentHealth;

        public float invincibilityTimeAfterIt = 3f;
        public bool isInvincible = false;
        public float invincibilityFlashDelay = 0.2f;
        public SpriteRenderer graphics;

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

    public void TakeDamage(int damage)
        {
            if(!isInvincible)
            {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
            }
            if(currentHealth <= 0)
             {
                 Die();
                 return;
             }
         
        }
        public IEnumerator InvincibilityFlash()
        {
            while (isInvincible)
            {
                graphics.color =new Color(1f, 1f, 1f, 0f);
                yield return new WaitForSeconds(invincibilityFlashDelay);
                graphics.color =new Color(1f, 1f, 1f, 1f);
                yield return new WaitForSeconds(invincibilityFlashDelay);
            }
        }

        public IEnumerator HandleInvincibilityDelay()
        {
            yield return new WaitForSeconds(invincibilityTimeAfterIt);
            isInvincible = false;
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
