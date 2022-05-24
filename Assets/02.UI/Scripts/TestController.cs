using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TestController : MonoBehaviour
{
    private Text timer;
    private Text question;
    private Text TestOver;
    private Text textA;
    private Text textB;
    private Text textC;
    private Text textD;
    private Toggle toggleA;
    private Toggle toggleB;
    private Toggle toggleC;
    private Toggle toggleD;
    private Text scorePanel;
    private Text nextQuestionText;
    private int TotalTime = 600;
    private int minutes, seconds, temp, score;
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        question = GameObject.Find("question").GetComponent<Text>();
        TestOver = GameObject.Find("TestOver").GetComponent<Text>();
        textA = GameObject.Find("LabelA").GetComponent<Text>();
        textB = GameObject.Find("LabelB").GetComponent<Text>();
        textC = GameObject.Find("LabelC").GetComponent<Text>();
        textD = GameObject.Find("LabelD").GetComponent<Text>();
        toggleA = GameObject.Find("A").GetComponent<Toggle>();
        toggleB = GameObject.Find("B").GetComponent<Toggle>();
        toggleC = GameObject.Find("C").GetComponent<Toggle>();
        toggleD = GameObject.Find("D").GetComponent<Toggle>();
        scorePanel = GameObject.Find("Score").GetComponent<Text>();
        nextQuestionText = GameObject.Find("NextQuestionText").GetComponent<Text>();

        StartCoroutine(Time());
        FirstQuestion();
    }
    void Update()
    {
        if (TotalTime == 0 || temp == 12)
        {
            SceneManager.LoadScene("TransitionInterface");
        }
    }
    private void FirstQuestion()
    {

        score = 0;
        question.text = "1.实验终止时应该首先关闭（    ）。";
        textA.text = "A.空气进口阀门。";
        textB.text = "B.空气出口阀门。";
        textC.text = "C.风机开关";
        textD.text = "D.蒸汽加热器开关";
        scorePanel.text = "当前分数:" + 0 + "分";

        temp = 2;
    }
    public void NextQuestion()
    {
        Debug.Log("下一题");
        switch (temp)
        {
            case 2:
                {
                    question.text = "2.开启蒸汽阀门前应该（    ）。";
                    textA.text = "A.打开风机开关";
                    textB.text = "B.检查水箱水量";
                    textC.text = "C.打开空气进口阀门";
                    textD.text = "D.调节风机转速";
                    temp = 3;
                    if (toggleD.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 3:
                {

                    question.text = "3.空气的定性温度是（    ）。";
                    textA.text = "A.空气进口温度";
                    textB.text = "B.空气出口温度";
                    textC.text = "C.T进+T出/2";
                    textD.text = "D.（T进+T出）/2";
                    temp = 4;
                    if (toggleB.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 4:
                {
                    question.text = "4.套管换热器被加热时空汽侧给热系数公式中αi与Re和Pr关系分别为（    ）次方。";
                    textA.text = "A.0.4；0.6";
                    textB.text = "B.0.4；0.8";
                    textC.text = "C.0.8；0.4";
                    textD.text = "D.0.8；0.3";

                    temp = 5;
                    if (toggleD.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 5:
                {

                    question.text = "5.蒸汽侧存在不冷凝气体会使测定的αi（    ）。";
                    textA.text = "A.降低";
                    textB.text = "B.增加";
                    textC.text = "C.不变";
                    textD.text = "D.不确定";

                    temp = 6;
                    if (toggleC.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 6:
                {

                    question.text = "6.由经验关联式可知，水平管外的蒸汽冷凝给热系数αo正比于管外径do的（   ）次方。";
                    textA.text = "A.0.25";
                    textB.text = "B.0.35";
                    textC.text = "C.0.4";
                    textD.text = "D.0.8";
                    temp = 7;
                    if (toggleA.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 7:
                {

                    question.text = "7.一般情况下，钢制水平管外蒸汽冷凝为（    ）。";
                    textA.text = "A.核状冷凝";
                    textB.text = "B.膜状冷凝";
                    textC.text = "C.液滴冷凝";
                    textD.text = "D.不确定";
                    temp = 8;
                    if (toggleA.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 8:
                {

                    question.text = "8.在给热系数测定中采取旁路调节空气流量，阀门开度越大，则换热器中空气流量越（    ）。";
                    textA.text = "A.大";
                    textB.text = "B.不变";
                    textC.text = "C.小";
                    textD.text = "D.相同";
                    temp = 9;
                    if (toggleB.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 9:
                {

                    question.text = "9.对于套管换热器，稳态传热下，传热温差大的流体一侧，阻力（    ）。";
                    textA.text = "A.相等";
                    textB.text = "B.不确定";
                    textC.text = "C.小";
                    textD.text = "D.大";
                    temp = 10;
                    if (toggleC.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }

            case 10:
                {

                    question.text = "10.本实验的传热阻力在（   ）侧。";
                    textA.text = "A.导热材质";
                    textB.text = "B.蒸汽侧";
                    textC.text = "C.空气侧";
                    textD.text = "D.保温层";
                    temp = 11;
                    if (toggleD.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    break;
                }
            case 11:
                {
                    if (toggleC.isOn == true)
                    {
                        score += 10;
                    }
                    toggleA.SetIsOnWithoutNotify(false);
                    toggleB.SetIsOnWithoutNotify(false);
                    toggleC.SetIsOnWithoutNotify(false);
                    toggleD.SetIsOnWithoutNotify(false);
                    scorePanel.text = "当前分数:" + score.ToString() + "分";
                    TestOver.text = "笔试结束";
                    nextQuestionText.text = "开始实操测试";
                    temp = 12;
                    break;
                }
        }
    }
    /// <summary>
    /// 倒计时
    /// </summary>
    /// <returns></returns>
    IEnumerator Time()
    {
        while (TotalTime >= 0)
        {
            minutes = TotalTime / 60;
            seconds = TotalTime % 60;
            timer.text = "剩余时间:" + minutes.ToString() + "分" + seconds.ToString() + "秒";
            yield return new WaitForSeconds(1);
            TotalTime--;
        }
    }
}