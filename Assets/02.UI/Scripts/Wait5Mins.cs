using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Wait5Mins : MonoBehaviour
{
    private Image load;//进度条的图片
    private float culload = 0;//已加载的进度
    private Text loadtext;//百分制显示进度加载情况
    private Slider slider;
    float totalTime = 5f;
    FirstPersonController enableFPS;
    void Start()
    {
        slider = GameObject.Find("Wait5Mins").GetComponent<Slider>();
        load = GameObject.Find("Background").GetComponent<Image>();
        loadtext = GameObject.Find("PercentText").GetComponent<Text>();
        enableFPS = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

    }
    public void Wait5MinsFun()
    {
        StartCoroutine(Time());
    }
    IEnumerator Time()
    {
        while (totalTime >= 0)
        {
            loadtext.text = "剩余时间:" + ((int)totalTime).ToString() + "分钟";
            culload = (5f - totalTime) / 5;
            load.fillAmount = culload;
            slider.value = culload;
            totalTime -= 0.02f;
            enableFPS.enabled = false;
            yield return new WaitForSeconds(0.02f);
        }
        totalTime = 5;
        enableFPS.enabled = true;
    }
}
