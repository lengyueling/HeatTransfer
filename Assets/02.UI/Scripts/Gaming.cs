using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityStandardAssets.Characters.FirstPerson;
public class Gaming : MonoBehaviour
{
    bool tipsMenuIsIn = false;
    bool scratchPaperIsIn = false;
    bool isPasuse = false;
    FirstPersonController enableFPS;
    RectTransform gamingTipsMenuForward;
    RectTransform gamingTipsMenuBackward;
    RectTransform scratchPaperMenuForward;
    RectTransform scratchPaperMenuBackward;
    Image GamePauseForward;
    Image GamePauseBackward;


    Text presentation;
    Text presentation1;
    Image Curve;
    Image report;
    private void Start()
    {
        //实验总结动画
        Curve = GameObject.Find("Curve").GetComponent<Image>();
        report = GameObject.Find("report").GetComponent<Image>();
        enableFPS = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        presentation = GameObject.Find("presentation").GetComponent<Text>();
        presentation1 = GameObject.Find("presentation1").GetComponent<Text>();
        //实验提示动画
        gamingTipsMenuForward = GameObject.Find("GamingTipsMenu").GetComponent<RectTransform>();
        gamingTipsMenuBackward = GameObject.Find("GamingTipsMenu").GetComponent<RectTransform>();
        gamingTipsMenuForward.DOAnchorPosX(-250, 0.5f).SetId("gamingTipsMenuForward").SetAutoKill(false);
        gamingTipsMenuBackward.DOAnchorPosX(255, 0.5f).SetId("gamingTipsMenuBackward").SetAutoKill(false);
        //数据记录动画
        scratchPaperMenuForward = GameObject.Find("ScratchPaper").GetComponent<RectTransform>();
        scratchPaperMenuBackward = GameObject.Find("ScratchPaper").GetComponent<RectTransform>();
        scratchPaperMenuForward.DOAnchorPosX(250, 0.5f).SetId("scratchPaperMenuForward").SetAutoKill(false);
        scratchPaperMenuBackward.DOAnchorPosX(-300, 0.5f).SetId("scratchPaperMenuBackward").SetAutoKill(false);
        //暂停动画
        GamePauseForward = GameObject.Find("Pause").GetComponent<Image>();
        GamePauseBackward = GameObject.Find("Pause").GetComponent<Image>();
        GamePauseForward.DOColor(new Color(1,1,1,1), 0.3f).SetId("GamePauseForward").SetAutoKill(false);//显示暂停
        GamePauseBackward.DOColor(new Color(1,1,1,0), 0.3f).SetId("GamePauseBackward").SetAutoKill(false);
        
        DOTween.Pause("gamingTipsMenuForward");
        DOTween.Pause("gamingTipsMenuBackward");
        DOTween.Pause("scratchPaperMenuForward");
        DOTween.Pause("scratchPaperMenuBackward");
        DOTween.Pause("GamePauseForward");
        DOTween.Pause("GamePauseBackward");
        DOTween.Pause("gamingSummary");
        report.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && scratchPaperIsIn == false)
        {
            GamingScratchPaperMenuForward();
        }
        if (Input.GetKeyDown(KeyCode.E) && scratchPaperIsIn == true)
        {
            GamingScratchPaperMenuBackward();
        }
        if (Input.GetKeyDown(KeyCode.P) && tipsMenuIsIn == false)
        {
            GamingTipsMenuForward();
        }
        if (Input.GetKeyDown(KeyCode.P) && tipsMenuIsIn == true)
        {
            GamingTipsMenuBackward();
        }
        if (Input.GetKeyDown(KeyCode.G) && isPasuse == false)
        {
            isPauseForward();
        }
        if (Input.GetKeyDown(KeyCode.G) && isPasuse == true)
        {
            isPauseBackward();
        }
    }
    public void isPauseForward()
    {
        DOTween.Restart("GamePauseForward");
        enableFPS.enabled = false;
        StartCoroutine(OpenPanelTimer(2));
    }
    public void isPauseBackward()
    {
        DOTween.Restart("GamePauseBackward");
        enableFPS.enabled = true;
        StartCoroutine(ClosePanelTimer(2));
    }
    public void GamingScratchPaperMenuForward()
    {
        DOTween.Restart("scratchPaperMenuForward");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enableFPS.enabled = false;
        StartCoroutine(OpenPanelTimer(0));
    }
    public void GamingScratchPaperMenuBackward()
    {
        DOTween.Restart("scratchPaperMenuBackward");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enableFPS.enabled = true;
        StartCoroutine(ClosePanelTimer(0));
    }
        public void GamingTipsMenuForward()
    {
        DOTween.Restart("gamingTipsMenuForward");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        enableFPS.enabled = false;
        StartCoroutine(OpenPanelTimer(1));
    }
    public void GamingTipsMenuBackward()
    {
        DOTween.Restart("gamingTipsMenuBackward");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enableFPS.enabled = true;
        StartCoroutine(ClosePanelTimer(1));
    }
    public void Announcement()
    {
        presentation.text =
            "\u3000\u3000" + "1.水箱的水少于1/2应该加水，较合适的水量应该是1/2—2/3" + "\n" +
            "\n\u3000\u3000" + "2.空气流量由旁路调控，旁路阀为截止阀，同时阀门应该全开" + "\n" +
           "\n\u3000\u3000" + "3.蒸汽进口阀门应该全开，阀门为截止阀，旋转至不能在继续转动为止" + "\n" +
            "\n\u3000\u3000" + "4.打开加热开关应检查仪表箱上的数字变化是否正常" + "\n" +
            "\n\u3000\u3000" + "5.逐渐调小旁路阀门，让空气流量变化相对平缓，提高测定结果的准确性" + "\n" +
            "\n\u3000\u3000" + "6.转动截止阀应该注意转动方向，同时应该缓慢旋转，每次旋转角度为360°" + "\n" +
            "\n\u3000\u3000" + "7.在关闭加热开关后再关闭风机，因为冷空气会冷却套管换热器，同时减少冷却时间" + "\n" +
            "\n\u3000\u3000" + "8.关闭总电源后应该将各个阀门回复恢复至原位，保证下次做实验时的完整性和复现性";
    }
    public void Step()
    {
        presentation.text =
            "实验准备阶段：" + "\n\u3000\u3000" + "1.打开电闸" + "\n\u3000\u3000" + "2.检查2/3水箱" + "\n\u3000\u3000" + "3.打开旁路阀门" + "\n\u3000\u3000" + "4.打开空气进口阀门" + "\n\u3000\u3000" + "5.打开空气出口阀门" + "\n\u3000\u3000" + "6.打开蒸汽进口阀门" + "\n\u3000\u3000" + "7.打开总开关" + "\n\u3000\u3000" + "8.打开加热开关" + "\n\u3000\u3000" + "9.等待五分钟" + "\n\u3000\u3000" + "10.启动风机" + "\n\u3000\u3000" + "11.等待五分钟" + "\n" + "\n" +
            "实验操作和数据记录阶段：" + "\n\u3000\u3000" + "12.调小旁路阀门" + "\n\u3000\u3000" + "13.等待五分钟" + "\n\u3000\u3000" + "14.记录实验结果" + "\n" + "\n" +
            "实验整理阶段：" + "\n\u3000\u3000" + "15.关闭加热开关" + "\n\u3000\u3000" + "16.等待五分钟" + "\n\u3000\u3000" + "17.关闭风机" + "\n\u3000\u3000" + "18.等待五分钟" + "\n\u3000\u3000" + "19.关闭总电源" + "\n\u3000\u3000" + "20.关闭电闸";
    }
    public void Announcement1()
    {
        report.gameObject.SetActive(false);
        Curve.gameObject.SetActive(false);
        presentation1.text =
            "\n" + "\n" + "注意事项：" + "\n" + "\n" +
            "\u3000\u3000" + "1.水箱的水少于1/2应该加水，较合适的水量应该是1/2—2/3" + "\n" +
            "\n\u3000\u3000" + "2.空气流量由旁路调控，旁路阀为截止阀，同时阀门应该全开" + "\n" +
           "\n\u3000\u3000" + "3.蒸汽进口阀门应该全开，阀门为截止阀，旋转至不能在继续转动为止" + "\n" +
            "\n\u3000\u3000" + "4.打开加热开关应检查仪表箱上的数字变化是否正常" + "\n" +
            "\n\u3000\u3000" + "5.逐渐调小旁路阀门，让空气流量变化相对平缓，提高测定结果的准确性" + "\n" +
            "\n\u3000\u3000" + "6.转动截止阀应该注意转动方向，同时应该缓慢旋转，每次旋转角度为360°" + "\n" +
            "\n\u3000\u3000" + "7.在关闭加热开关后再关闭风机，因为冷空气会冷却套管换热器，同时减少冷却时间" + "\n" +
            "\n\u3000\u3000" + "8.关闭总电源后应该将各个阀门回复恢复至原位，保证下次做实验时的完整性和复现性";
    }
    public void Step1()
    {
        report.gameObject.SetActive(false);
        Curve.gameObject.SetActive(false);
        presentation1.text = "\n" + "\n" +
           "\n\u3000\u3000\u3000\u3000" + "实验准备阶段：                   实验操作和数据记录阶段：                  实验整理阶段：" + "\n" +
           "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "1.打开电闸                                  12.调小旁路阀门                    15.关闭加热开关" +
           "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "2.检查2/3水箱                             13.等待五分钟                        16.等待五分钟" +
           "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "3.打开旁路阀门                           14.记录实验结果                    17.关闭风机" +
          "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "4.打开空气进口阀门                                                                  18.等待五分钟" +
          "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "5.打开空气出口阀门                                                                  19.关闭总电源" +
          "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "6.打开蒸汽进口阀门                                                                   20.关闭电闸" + "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "7.打开总开关" +
           "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "8.打开加热开关" + "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "9.等待五分钟" + "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "10.启动风机" + "\n\u3000\u3000\u3000\u3000\u3000\u3000" + "11.等待五分钟";
    }

    public void Report()
    {
        presentation1.text = "";
        report.gameObject.SetActive(true);
        Curve.gameObject.SetActive(false);
        report.enabled = true ;
    }
    public void FittingCurve()
    {
        report.gameObject.SetActive(false );
        presentation1.text = "";
        Curve.gameObject.SetActive(true);
    }  
    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync("StartInterface");
    }
    /// <summary>
    /// 打开面板协程
    /// </summary>
    /// <param name="flag">0数据记录 1实验提示 2暂停</param>
    /// <returns></returns>
    IEnumerator OpenPanelTimer(int flag)
    {
        yield return new WaitForSeconds(0.1f);  
        if (flag == 1)
        {
            tipsMenuIsIn = true;
        }
        if(flag == 0)
        {
            scratchPaperIsIn = true;
        }
        if (flag == 2)
        {
            isPasuse = true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="flag">0数据记录 1实验提示 2暂停</param>
    /// <returns></returns>
    IEnumerator ClosePanelTimer(int flag)
    {
        yield return new WaitForSeconds(0.1f);
        if (flag == 1)
        {
            tipsMenuIsIn = false;
        }
        if (flag == 0)
        {
            scratchPaperIsIn = false;
        }
        if (flag == 2)
        {
            isPasuse = false;
        }
    }
}