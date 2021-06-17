using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnCountText;
    [SerializeField] int turnCount = 10;


    // Start is called before the first frame update
    void Start()
    {
        turnCountText.text = turnCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
