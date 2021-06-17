using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Use();

    public abstract void AltUse();
    public abstract void CheckActive();

    public bool isActive;
}
