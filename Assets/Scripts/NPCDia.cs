using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDia : MonoBehaviour
{
    public GameObject dialog;
    public float diaTimer;
    public float diaTime = 4;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        diaTimer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (diaTimer > 0)
            diaTimer -= Time.deltaTime;
        else
            dialog.SetActive(false);
    }
    public void DialogPlay()
    {
        diaTimer = diaTime;
        if(UIHealth.intance.finTask == true)
        {
            text.text = "阿里嘎多，美羊羊桑";
        }
        dialog.SetActive(true);
        UIHealth.intance.hasTask = true;
        
    }
}
