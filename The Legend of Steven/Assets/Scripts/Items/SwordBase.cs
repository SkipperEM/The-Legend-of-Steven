using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SwordBase : ItemBase
{
    public abstract override void Use();
    public abstract override void AltUse();

    // VARS
    public Player player;
    public Image image;
    public bool isEquipped;
    public int damage = 1;
    public float swingSpeed = 1f;
    // Add Sounds
}
