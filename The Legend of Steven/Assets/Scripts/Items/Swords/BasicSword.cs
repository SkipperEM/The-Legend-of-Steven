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

    }

    public override void AltUse()
    {

    }

    public void EquipItem()
    {
        player.Equip(gameObject, image);
        //player.items.Add(gameObject);
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
