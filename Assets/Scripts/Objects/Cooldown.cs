using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cooldown : MonoBehaviour
{
    public float cooldownTime;
    public float nextFireTime;
    public TextMeshProUGUI CDTimer;
    public bool consumed;
    private float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (consumed)
        {
            CDTimer.text = ((int)(nextFireTime - currentTime*288)/60).ToString();
            if(Time.time*288 > nextFireTime)
            {
                consumed = false;
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
