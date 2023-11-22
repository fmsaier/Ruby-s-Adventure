using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private RectTransform rectTransform;
    private float width;

    public AudioSource audioSource;

    public bool hasTask;
    public bool finTask;
    private bool isPlay;

    public AudioClip cilp;
    public static UIHealth intance {  get; private set; }
    private void Awake()
    {
        intance = this;
    }

    private void Start()
    {
        hasTask = false;
        rectTransform = GetComponent<RectTransform>();
        width = rectTransform.rect.width;
        isPlay = false;
    }
    void Update()
    {
        if(Robot.fixedNum == 3 && !isPlay)
        {
            isPlay = true;
            if(!audioSource.isPlaying)
                audioSource.Play();
            finTask = true;        
        }
           
    }
    public void SetHpUISize(float percent)
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width * percent);
    }
}
