using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SetItemActive))]
public class BasicSword : SwordBase, IEquippable
{
    [SerializeField] SetItemActive setItemActive;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void Use()
    {
        StartCoroutine(Attack());
    }

    public override void AltUse()
    {

    }

    public override void CheckActive()
    {
        if (isActive)
        {
            player.animator.SetBool("basic", true);
        }
        else
        {
            player.animator.SetBool("basic", false);
        }
    }

    IEnumerator Attack()
    {
        player.animator.SetBool("attacking", true);
        yield return new WaitForSeconds(0.1f);
        player.animator.SetBool("attacking", false);
    }

    public void EquipItem()
    {
        transform.SetParent(player.transform);
        transform.position = transform.parent.position;
        player.Equip(gameObject, image);
        isEquipped = true;
    }

    public void DropItem()
    {
        player.items.Remove(gameObject);
        isEquipped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isEquipped)
        {
            if (player.items.Count < player.inventorySize)
            {
                EquipItem();
                setItemActive.ToggleVis(false);
            }
        }
    }

    
}
