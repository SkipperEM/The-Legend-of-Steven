using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    

    // CACHE
    [SerializeField] Rigidbody2D rb;

    // VARS
    [SerializeField] float moveSpeed = 5000f;
    public int inventorySize = 5;
    public List<GameObject> items;



    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector2 movePlayer = new Vector2(xMove, yMove);
        rb.AddForce(movePlayer);
    }
}
