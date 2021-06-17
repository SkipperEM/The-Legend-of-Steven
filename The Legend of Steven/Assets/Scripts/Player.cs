using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator animator;

    // CACHE
    [SerializeField] Rigidbody2D rb;

    // VARS
    [SerializeField] float moveSpeed = 5000f;
    public int inventorySize = 5;
    [SerializeField] int currentItem = -1;
    [SerializeField] int previousItem;
    public List<GameObject> items;
    public InventorySlot[] inventorySlots;
    public GameObject currentActiveItem;



    void Update()
    {
        if (previousItem != currentItem)
        {
            SelectItem();
        }
        previousItem = currentItem;
        ProcessInput();
        MovePlayer();
        
    }

    void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0) && currentActiveItem != null)
        {
            currentActiveItem.GetComponent<ItemBase>().Use();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentItem = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentItem = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentItem = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentItem = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentItem = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentItem = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            currentItem = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            currentItem = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentItem = 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            currentItem = 9;
        }

    }

    void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector2 movePlayer = new Vector2(xMove, yMove);
        rb.AddForce(movePlayer);

        animator.SetFloat("Horizontal", xMove);
        animator.SetFloat("Vertical", yMove);
        animator.SetFloat("Speed", movePlayer.sqrMagnitude);

        if (xMove >= 0.9)
        {
            animator.SetBool("right", true);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        else if (xMove <= -0.9)
        {
            animator.SetBool("right", false);
            animator.SetBool("left", true);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
        else if (yMove >= 0.9)
        {
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", true);
            animator.SetBool("down", false);
        }
        else if (yMove <= -0.9)
        {
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("down", true);
        }
    }

    void SelectItem()
    {
        int inventoryIndex = 0;

        foreach(GameObject item in items)
        {
            if (currentItem == inventoryIndex)
            {
                //inventorySlots[inventoryIndex].GetComponent<Image>().color.;
                currentActiveItem = item;
                item.GetComponent<ItemBase>().isActive = true;
                item.GetComponent<ItemBase>().CheckActive();
                break;
            }
            inventoryIndex++;
        }
    }

    public void Equip(GameObject item, Image image)
    {
        items.Add(item);
        
        foreach(InventorySlot slot in inventorySlots)
        {
            if (slot.isTaken == false)
            {
                image.transform.position = slot.transform.position;
                image.gameObject.SetActive(true);
                slot.isTaken = true;
                break;
            }
        }
    }
}
