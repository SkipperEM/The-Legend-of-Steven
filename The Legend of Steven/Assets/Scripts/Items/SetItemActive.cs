using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemActive : MonoBehaviour
{
    public void ToggleVis(bool active)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = active;
        gameObject.GetComponent<BoxCollider2D>().enabled = active;
    }
}
