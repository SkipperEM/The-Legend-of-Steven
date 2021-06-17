using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5000f;
    [SerializeField] float timePassed = 0f;
    [SerializeField] float bulletForce = 500f;
    [SerializeField] float readyToShoot = 0.5f;

    // CACHE
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject bullet1;

    // UI
    [SerializeField] TextMeshProUGUI playerSpeedUI;
    [SerializeField] TextMeshProUGUI bulletSpeedUI;
    [SerializeField] TextMeshProUGUI shootSpeedUI;


    private void Start()
    {
        UpdateInterfaceStats();
    }

    private void UpdateInterfaceStats()
    {
        playerSpeedUI.text = moveSpeed.ToString();
        bulletSpeedUI.text = bulletForce.ToString();
        shootSpeedUI.text = readyToShoot.ToString();
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        MovePlayer();

        if (timePassed > readyToShoot)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                FireBulletLeftRight(-1);
                TimeReset();
                // Shoots Left
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                FireBulletLeftRight(1);
                TimeReset();
                // Shoots Right
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                FireBulletUpDown(1);
                TimeReset();
                // Shoots Up
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                FireBulletUpDown(-1);
                TimeReset();
                // Shoots Down
            }
        }
    }

    void TimeReset()
    {
        timePassed = 0f;
    }

    void FireBulletLeftRight(int direction)
    {
        GameObject bullet = Instantiate(bullet1, gameObject.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * bulletForce * direction);
    }

    void FireBulletUpDown(int direction)
    {
        GameObject bullet = Instantiate(bullet1, gameObject.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletForce * direction);
    }

    void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector2 movePlayer = new Vector2(xMove, yMove);
        rb.AddForce(movePlayer);
    }
}
