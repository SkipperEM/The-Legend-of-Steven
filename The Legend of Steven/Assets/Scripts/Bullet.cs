using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletRange = 2f;
    [SerializeField] int bulletDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMe", bulletRange);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit " + collision.gameObject.name);
            collision.GetComponent<EnemyController>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Untagged")
        {
            Destroy(gameObject);
            Debug.Log("I hit " + collision.gameObject.name);
        }
    }
}
