using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemActive : MonoBehaviour
{
    public void ToggleVis(bool active)
    {
        gameObject.SetActive(active);
    }
}
