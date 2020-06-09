using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    public Slider timebar;
    public float maximumValue;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        timebar.value = timebar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        timebar.maxValue = maximumValue;
        timebar.value = startTime;
        if (timebar.value >= timebar.maxValue)
        {
            //timebar.value = timebar.maxValue;
            startTime = 0;
            gameObject.SetActive(false);
        }
    }
}
