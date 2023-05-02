using UnityEngine.SceneManagement;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int bulletDmg;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            Shake shake = collision.gameObject.GetComponentInChildren<Shake>();
            if(playerHealth != null)
            {
                shake.start = true;
                playerHealth.TakeDamage(bulletDmg);
            }

            if (playerHealth.health<= 0f)
            {
                Die();
                Debug.Log("Dead");
            }
            
            
        }
        
        Destroy(this.gameObject);
    }

    private void Die()
    {
        SceneManager.LoadScene("Breach");
    }
    
    
    
    
    

}
