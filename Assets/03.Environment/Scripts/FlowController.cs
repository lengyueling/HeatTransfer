using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HighlightPlus;

public class FlowController : MonoBehaviour
{
    private FaMenController m1_FaMenController;
    private FaMenController m2_FaMenController;
    private FaMenRotate m1_FaMenRotate;
    private FaMenRotate m2_FaMenRotate;
    private FaMenRotate m3_FaMenRotate;
    private ComputerUIController m_ComputerUIController;
    private MainSwitch m_MainSwitch;
    private ElectricSwitch m_ElectricSwitch;
    private HeatingSwitch m_HeatingSwitch;
    private MainOpen m_MainOpen;
    private FanSwitch m_FanSwitch;
    private HeatingOpen m_HeatingOpen;
    private FanOpen m_FanOpen;
    private ColdAirInletTemperature m_ColdAirInletTemperature;
    /*
     * 计数器：
     * 0.打开电闸
     * 1.检查2/3水箱
     * 2.开旁路调节阀门
     * 3.空气进口阀
     * 4.空气出口阀
     * 5.打开总开关
     * 6.打开加热开关
     * 7.调整电压
     * 8.启动风机
     * 9.调小旁路调节阀门
     * 10.关闭加热开关
     * 11.关闭风机
     * 12.关闭总电源
     * 13.关闭电闸
     */
    bool[] procedure = new bool[10] { false, false, false, false, false, false, false, false, false, false };



    //设备开关标志
    int inputF = 0;
    
    private Text uiObjectInformation;
    private Text uiTips;

    private HighlightEffect[] objectHighlight;
    /*
     * 实例化所有对象，为后续实现函数接口
     */
    private void Awake()
    {
        uiObjectInformation = GameObject.Find("ObjectInformation").GetComponent<Text>();//实例化TextUI
        uiTips = GameObject.Find("Tips").GetComponent<Text>();//实例化TextUI

        m1_FaMenController = GameObject.Find("FaMen1").GetComponent<FaMenController>();//实例化冷空气进口阀门
        m2_FaMenController = GameObject.Find("FaMen2").GetComponent<FaMenController>();//实例化冷空气出口阀门
        m1_FaMenRotate = GameObject.Find("FaMen3").GetComponent<FaMenRotate>();//实例化截止阀门1
        m2_FaMenRotate = GameObject.Find("FaMen4").GetComponent<FaMenRotate>();//实例化截止阀门2
        m3_FaMenRotate = GameObject.Find("FaMen5").GetComponent<FaMenRotate>();//实例化截止阀门3
        m_ComputerUIController = GameObject.Find("ComputerUI").GetComponent<ComputerUIController>();//实例化电脑UI
        m_MainSwitch = GameObject.Find("MainSwitch").GetComponent<MainSwitch>();//实例化总电源 关键
        m_ElectricSwitch = GameObject.Find("ElectricSwitch").GetComponent<ElectricSwitch>();//实例化电闸
        m_HeatingSwitch = GameObject.Find("HeatingSwitch").GetComponent<HeatingSwitch>();//实例化加热电源  关键
        m_FanSwitch = GameObject.Find("FanSwitch").GetComponent<FanSwitch>();//实例化风机 关键
        m_MainOpen = GameObject.Find("MainOpen").GetComponent<MainOpen>();//实例化总电源 开键
        m_HeatingOpen = GameObject.Find("HeatingOpen").GetComponent<HeatingOpen>();//实例化加热电源 开键
        m_FanOpen = GameObject.Find("FanOpen").GetComponent<FanOpen>();//实例化风机电源 开键
        m_ColdAirInletTemperature = GameObject.Find("ColdAirInletTemperature").GetComponent<ColdAirInletTemperature>();
    }
private void Start()
    {
      //  m_ElectricSwitch.OpenControl(false);

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (inputF)
            {
                case 1:
                    {
                        uiObjectInformation.text = "电闸";
                        uiTips.text = "按“F”打开";
                        objectHighlight[0].highlighted = true;
                        inputF = 1;
                        m_ElectricSwitch.OpenControl();
                        break;
                    }
                case 2:
                    {
                        uiObjectInformation.text = "电脑";
                        uiTips.text = "按“F”进入交互";
                        objectHighlight[1].highlighted = true;
                        inputF = 2;
                        m_ComputerUIController.MoveComputerUI();
                        break;
                    }
                case 3:
                    {
                        uiObjectInformation.text = "水箱";
                        uiTips.text = "水深约2/3";
                        inputF = 3;
                        objectHighlight[2].highlighted = true;

                        break;
                    }
                case 4:
                    {
                        uiObjectInformation.text = "截止阀门";
                        uiTips.text = "按“F”打开" +
                           " 按“G”关闭";
                        objectHighlight[3].highlighted = true;
                        inputF = 4;
                        m2_FaMenRotate.RotateControl();
                        break;
                    }
                case 5:
                    {
                        uiObjectInformation.text = "冷空气进口阀门";
                        uiTips.text = "按“F”打开" +
                            " 按“G”关闭";
                        objectHighlight[4].highlighted = true;
                        inputF = 5;
                        m1_FaMenController.InControl();
                        break;
                    }
                case 6:
                    {
                        uiObjectInformation.text = "冷空气出口阀门";
                        uiTips.text = "按“F”打开" +
                            " 按“G”关闭";
                        objectHighlight[5].highlighted = true;
                        inputF = 6;
                        m2_FaMenController.OutControl();
                        break;
                    }
                case 7:
                    {
                        uiObjectInformation.text = "总电源";
                        uiTips.text = "按“F”打开";
                        objectHighlight[6].highlighted = true;
                        inputF = 7;
                        m_MainOpen.MainOpenControl();
                        break;
                    }
                case 8:
                    {
                        uiObjectInformation.text = "加热电源";
                        uiTips.text = "按“F”打开";
                        objectHighlight[7].highlighted = true;
                        inputF = 8;
                        m_HeatingOpen.HeatingOpenControl();
                        break;
                    }
                case 9:
                    {
                        uiObjectInformation.text = "风机电源";
                        uiTips.text = "按“F”打开";
                        objectHighlight[8].highlighted = true;
                        inputF = 9;
                        m_FanOpen.FanOpenControl();
                        break;
                    }
                case 10:
                    {
                        uiObjectInformation.text = "加热电源";
                        uiTips.text = "按“F”关闭";
                        objectHighlight[9].highlighted = true;
                        inputF = 10;
                        m_HeatingSwitch.HeatingSwitchControl();
                        break;
                    }
                case 11:
                    {
                        uiObjectInformation.text = "风机电源";
                        uiTips.text = "按“F”打开";
                        objectHighlight[10].highlighted = true;
                        inputF = 11;
                        m_FanSwitch.FanSwitchControl();
                        break;
                    }
                case 12:
                    {
                        uiObjectInformation.text = "总电源";
                        uiTips.text = "按“F”关闭";
                        objectHighlight[11].highlighted = true;
                        inputF = 12;
                        m_MainSwitch.MainSwitchControl();
                        break;
                    }



                case 13:
                    {
                        uiObjectInformation.text = "截止阀门";
                        uiTips.text = "按“F”打开" +
                             " 按“G”关闭";
                        objectHighlight[12].highlighted = true;
                        inputF = 13;
                        m1_FaMenRotate.RotateControl();
                        break;
                    }
                case 14:
                    {
                        uiObjectInformation.text = "截止阀门";
                        uiTips.text = "按“F”打开" +
                           " 按“G”关闭";
                        objectHighlight[13].highlighted = true;
                        inputF = 14;
                        m3_FaMenRotate.RotateControl();
                        break;
                    }

                default:
                    {
                        inputF = 0;
                        break;
                    }
            }
        }

    }
}
