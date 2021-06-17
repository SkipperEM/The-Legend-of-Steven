using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void TakeDamage(int damage)
    {
            health -= damage;
            CheckDeath();
    }

    void CheckDeath()
    {
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
