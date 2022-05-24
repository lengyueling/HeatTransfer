using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using UnityStandardAssets.Characters.FirstPerson;
public class GameMenu : MonoBehaviour
{
    GameStart gameStart;
    Text presentation;
    RectTransform settingMenuForward;
    RectTransform settingMenuBackward;
    RectTransform introductionMenuForward;
    RectTransform introductionMenuBackward;
    RectTransform aboutUsMenuForward;
    RectTransform aboutUsMenuBackward;
    RectTransform testMenu;
    FirstPersonController enableFPS;
    private void Awake()
    {
        //开始界面
        if (SceneManager.GetActiveScene().name.Equals("StartInterface"))
        {
            gameStart = GameObject.Find("PressAnyKeyToContinue").GetComponent<GameStart>();
            settingMenuForward = GameObject.Find("SettingMenu").GetComponent<RectTransform>();
            settingMenuBackward = GameObject.Find("SettingMenu").GetComponent<RectTransform>();
            aboutUsMenuForward = GameObject.Find("AboutUs").GetComponent<RectTransform>();
            aboutUsMenuBackward = GameObject.Find("AboutUs").GetComponent<RectTransform>();

            //实验介绍文字
            presentation = GameObject.Find("Presentation").GetComponent<Text>();
            //实验介绍动画
            introductionMenuForward = GameObject.Find("IntroductionMenu").GetComponent<RectTransform>();
            introductionMenuBackward = GameObject.Find("IntroductionMenu").GetComponent<RectTransform>();
        }
        //实验界面
        if (SceneManager.GetActiveScene().name.Equals("GameInterface"))
        {
            enableFPS = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        }
        //dotween
        settingMenuForward.DOLocalMoveX(0, 0.5f).SetId("settingMenuForward").SetAutoKill(false);
        settingMenuBackward.DOLocalMoveX(1500, 0.5f).SetId("settingMenuBackward").SetAutoKill(false);
        introductionMenuForward.DOLocalMoveX(0, 0.5f).SetId("introductionMenuForward").SetAutoKill(false);
        introductionMenuBackward.DOLocalMoveX(1900, 0.5f).SetId("introductionMenuBackward").SetAutoKill(false);
        aboutUsMenuForward.DOLocalMoveX(0,0.5f).SetId("aboutUsMenuForward").SetAutoKill(false);
        aboutUsMenuBackward.DOLocalMoveX(1500,0.5f).SetId("aboutUsMenuBackward").SetAutoKill(false);
        DOTween.Pause("settingMenuForward");
        DOTween.Pause("settingMenuBackward");
        DOTween.Pause("introductionMenuForward");
        DOTween.Pause("introductionMenuBackward");
        DOTween.Pause("gamingTipsMenuBackward");
        DOTween.Pause("aboutUsMenuForward");
        DOTween.Pause("aboutUsMenuBackward");
    }
    //主菜单
    public void GameStart()
    {
        SceneManager.LoadScene("TransitionInterface");
        DOTween.PlayBackwards("settingMenuMove");
    }
    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
    public void GameSetting()
    {
        DOTween.Restart("settingMenuForward");
        DOTween.PlayBackwards("gameMenuMove");
    }
    public void GameIntroduction()
    {
        DOTween.Restart("introductionMenuForward");
        DOTween.PlayBackwards("gameMenuMove");
    }
    public void GameTest()
    {
        SceneManager.LoadScene("TestInterface");
        Debug.Log("开始考试");

    }
    public void AboutUs()
    {
        DOTween.Restart("aboutUsMenuForward");
        DOTween.PlayBackwards("gameMenuMove");
        Debug.Log("关于我们");
    }
    //关于我们内
    public void AboutUsBackMainMenu()
    {
        DOTween.Restart("aboutUsMenuBackward");
        DOTween.PlayForward("gameMenuMove");
    }
    //实验设置内
    public void SettingBackMainMenu()
    {
        DOTween.Restart("settingMenuBackward");
        DOTween.PlayForward("gameMenuMove");
    }
    
    //实验介绍
    public void Synopsis()
    {
        presentation.text =
            "\u3000\u3000"+"本实验以“套管换热器”为实验设备，测定对流给热系数及总传热系数。通过阀门控制空气流量，进而控制进口空气流量，进行最基础的实验测定。" + 
            "\n\u3000\u3000"+ "同时，我们提供了多种可调节的参数，例如:不同的管道材质和管道类型，改变管道的粗糙度，不同的加热流体，提供不同的热流体进口温度，可供选择的空气进口温度和大气压强，来模拟不同地理位置的实验结果，也可以将光滑管路改成强化管路，进行设备的拆装。" +
            "\n\u3000\u3000"+"在多样化的条件下，可直观的了解实验过程，增强对化工知识的理解，加深对化工设备的应用。";
    }
    public void Principle()
    {
        presentation.text =
            "" + "1.套管换热器中环隙通以水蒸气，内管通以空气或水蒸气冷凝放热以加热空气，在传热过程中达到稳定后。有以下关系式：" +
            "\n" + "VρCp（tco-tci）=αiAiΔt " +
            "\n" + "2.在水平管外，蒸汽冷凝给热系数（膜状冷凝）通过半经验公式得：" +
            "\n" +"α0=0.725（ρ^2gλ^3r/Δtμd0）^0.25" +
            "\n" +"3.流体在直管内强制对流时的给热系数可由半经验公式得：αi=0.023（λ / di）Re^0.8Pr^0.4";
    }
    public void Note()
    {
        presentation.text =
            "" + "1.一定要在套管换热器内管输以一定量的空气，方可开启蒸汽阀门，也必须在排除蒸汽管线上积存的凝结水后，方可把蒸汽通入套管换热器中。" +
            "\n" + "2.开始通入蒸汽时要缓慢打开蒸汽阀门，让蒸汽徐徐流入换热器中，逐渐加热。时间不得少于20分钟"+
            "\n" + "3.操作过程中整体压力一般控制在0.02MPa（表压）以下，因为在此条件下的压力比较容易控制。";
    }
    public void Purpose()
    {
        presentation.text =
            "" + "1.掌握无线传感温度计的测温方法" +
            "\n" + "2.掌握无线传感孔板流量计的工作原理，使用方法和测定方法" +
            "\n" + "3.测定水蒸气在圆形直管外的冷凝给热系数，掌握测定方法和测定公式" +
            "\n" + "4.实验为测定空气在圆形直管内的空气对流给热系数，掌握测定原理和计算公式";  
    }
    public void IntroductionBackMainMenu()
    {
        DOTween.Restart("introductionMenuBackward");
        DOTween.PlayForward("gameMenuMove");
    }
}