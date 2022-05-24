using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using HighlightPlus;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerTrigger : MonoBehaviour
{
    //高亮模块
    private HighlightEffect[] objectHighlight;
    private int quantityHighlight =24;//高亮物体数量
    //提示UI
    private Text uiObjectInformation;
    private Text uiTips;
    //3D字体
    private GameObject Text1;
    private GameObject Text2;
    private GameObject Text3;
    private GameObject Text4;
    private GameObject Text5;
    private GameObject Text6;
    private GameObject Text7;
    private GameObject Text8;
    private GameObject Text9;
    private GameObject Text10;
    private GameObject Text11;
    private GameObject Text12;
    private GameObject Text13;
    private GameObject Text14;
    private GameObject Text15;
    private GameObject Text16;
    //3D示数
    private GameObject FrequencyChanger;
    private GameObject HeaterVoltage;
    //射线检测
    private Raycast raycast;
    //获取其他脚本
    private FunctionCalculation m_GuanBiTemperature;
    private FunctionCalculation m_AirIn;
    private FunctionCalculation m_AirOut;
    private FunctionCalculation m_KongBanPressure;
    private FunctionCalculation m_HotAirIn;
    private FunctionCalculation m_HotAirOut;

    //关闭总电源后示数消失
    private FunctionCalculation GuanBiTemperature;
    private FunctionCalculation AirIn;
    private FunctionCalculation AirOut;
    private FunctionCalculation KongBanPressure;
    private FunctionCalculation HotAirIn;
    private FunctionCalculation HotAirOut;

    private FaMenController  m1_FaMenController;
    private FaMenController m2_FaMenController;
    private FaMenRotate m1_FaMenRotate;
    private FaMenRotate m2_FaMenRotate;
    private FaMenRotate m3_FaMenRotate;
    private MainSwitch m_MainSwitch;
    private ElectricSwitch m_ElectricSwitch;
    private HeatingSwitch m_HeatingSwitch;
    private MainOpen m_MainOpen;
    private FanSwitch m_FanSwitch;
    private HeatingOpen m_HeatingOpen;
    private FanOpen m_FanOpen;
    private ColdAirInletTemperature m_ColdAirInletTemperature;
    private WaterTank m_WaterTank;
    //结束后弹出总结菜单
    RectTransform gamingSummary;
    FirstPersonController enableFPS;
    //输入标签
    int inputF = 0;
     bool[] procedure = new bool[17] { false, false, false, false, false, false, false, false, false, false,false ,false,false ,false ,false,false,false };
    //开关标志
    private bool isdianzha = false;  //1->16
    private bool ispanglufamen = false;//2 -> 9  
    private bool kongqijinkoufamen = false;//3->13
    private bool kongqichukoufamen = false;//4->14
    private bool zhenqijinkoufamen = false;//5->15
    private bool zongkaiguan = false;//6
    private bool jiarekaiguan = false;//7
    private bool fengji = false;//8
    private bool guanbijiarekaiguan = false;//10
    private bool guanbifengji = false;//11
    private bool guanbizongkaiguan = false;//12
    //阀门开度初始值
    public int temp = 2880;
    //等待五分钟
    private Wait5Mins wait5Mints;
    RectTransform m_wait5Mints;
    //修改材质
    public Material green;
    public Material red;
    public Material normal;
    MeshRenderer fanOpen;
    MeshRenderer fanSwitch;
    MeshRenderer heatingOpen;
    MeshRenderer heatingSwitch;
    MeshRenderer mainOpen;
    MeshRenderer mainSwitch;

    private void Start()
    {
        Text1.SetActive(true);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Text5.SetActive(false);
        Text6.SetActive(false);
        Text7.SetActive(false);
        Text8.SetActive(false);
        Text9.SetActive(false);
        Text10.SetActive(false);
        Text11.SetActive(false);
        Text12.SetActive(false);
        Text13.SetActive(false);
        Text14.SetActive(false);
        Text15.SetActive(false);
        Text16.SetActive(false);

        FrequencyChanger.SetActive(false);
        HeaterVoltage.SetActive(false);
    }

    void Awake()
    {
        //3D提示模块
        Text1 = GameObject.Find("Text1");
        Text2 = GameObject.Find("Text2");
        Text3 = GameObject.Find("Text3");
        Text4 = GameObject.Find("Text4");
        Text5 = GameObject.Find("Text5");
        Text6 = GameObject.Find("Text6");
        Text7 = GameObject.Find("Text7");
        Text8 = GameObject.Find("Text8");
        Text9 = GameObject.Find("Text9");
        Text10= GameObject.Find("Text10");
        Text11= GameObject.Find("Text11");
        Text12= GameObject.Find("Text12");
        Text13= GameObject.Find("Text13");
        Text14= GameObject.Find("Text14");
        Text15= GameObject.Find("Text15");
        Text16= GameObject.Find("Text16");
        //3D示数
    
        FrequencyChanger = GameObject.Find("FrequencyChanger");
        HeaterVoltage = GameObject.Find("HeaterVoltage");


        //HUD提示
        uiObjectInformation = GameObject.Find("ObjectInformation").GetComponent<Text>();//实例化TextUI
        uiTips = GameObject.Find("Tips").GetComponent<Text>();//实例化TextUI

        //实验步骤中的实例化物体
        m1_FaMenController = GameObject.Find("FaMen1").GetComponent<FaMenController>();//实例化冷空气进口阀门
        m2_FaMenController = GameObject.Find("FaMen2").GetComponent<FaMenController>();//实例化冷空气出口阀门
        m1_FaMenRotate = GameObject.Find("FaMen3").GetComponent<FaMenRotate>();//实例化截止阀门1
        m2_FaMenRotate = GameObject.Find("FaMen4").GetComponent<FaMenRotate>();//实例化截止阀门2  旁路截止阀门
        m3_FaMenRotate = GameObject.Find("FaMen5").GetComponent<FaMenRotate>();//实例化截止阀门3
        m_MainSwitch=GameObject.Find("MainSwitch").GetComponent<MainSwitch>();//实例化总电源 关键
        m_ElectricSwitch= GameObject.Find("Fuse_Box_01").GetComponent<ElectricSwitch>();//实例化电闸
        m_HeatingSwitch = GameObject.Find("HeatingSwitch").GetComponent<HeatingSwitch>();//实例化加热电源  关键
        m_FanSwitch = GameObject.Find("FanSwitch").GetComponent<FanSwitch>();//实例化风机 关键
        m_MainOpen= GameObject.Find("MainOpen").GetComponent<MainOpen>();//实例化总电源 开键
        m_HeatingOpen = GameObject.Find("HeatingOpen").GetComponent<HeatingOpen>();//实例化加热电源 开键
        m_FanOpen = GameObject.Find("FanOpen").GetComponent<FanOpen>();//实例化风机电源 开键

        m_GuanBiTemperature=GameObject.Find("GuanBiTemperature").GetComponent<FunctionCalculation>();
        m_AirIn=GameObject.Find("AirIn").GetComponent<FunctionCalculation>();
        m_AirOut=GameObject.Find("AirOut").GetComponent<FunctionCalculation>();
        m_KongBanPressure= GameObject.Find("KongBanPressure").GetComponent<FunctionCalculation>();
        m_HotAirIn = GameObject.Find("HotAirIn").GetComponent<FunctionCalculation>();
        m_HotAirOut = GameObject.Find("HotAirOut").GetComponent<FunctionCalculation>();
        //关闭总电源后示数消失
        KongBanPressure=GameObject.Find("KongBanPressure").GetComponent<FunctionCalculation>();
        GuanBiTemperature= GameObject.Find("GuanBiTemperature").GetComponent<FunctionCalculation>();
        AirIn= GameObject.Find("GuanBiTemperature").GetComponent<FunctionCalculation>();
        AirOut= GameObject.Find("AirOut").GetComponent<FunctionCalculation>();
        HotAirIn = GameObject.Find("HotAirIn").GetComponent<FunctionCalculation>();
        HotAirOut = GameObject.Find("HotAirOut").GetComponent<FunctionCalculation>();

        m_ColdAirInletTemperature = GameObject.Find("ColdAirInletTemperature").GetComponent<ColdAirInletTemperature>();
        m_WaterTank = GameObject.Find("WaterTank").GetComponent<WaterTank>();
        //高亮模块
        objectHighlight = new HighlightEffect[quantityHighlight];
        objectHighlight[0] = GameObject.Find("ElectricSwitch").GetComponent<HighlightEffect>();//0.实例化电闸高亮模块
        objectHighlight[1] = GameObject.Find("WaterTank").GetComponent<HighlightEffect>();//2.实例化水箱高亮模块
        objectHighlight[2] = GameObject.Find("FaMen4").GetComponent<HighlightEffect>();//3.实例化截止阀门2高亮模块
        objectHighlight[3] = GameObject.Find("FaMen1").GetComponent<HighlightEffect>();//4.实例化冷空气进口阀门高亮模块
        objectHighlight[4] = GameObject.Find("FaMen2").GetComponent<HighlightEffect>();//5.实例化冷空气出口阀门高亮模块
        objectHighlight[5] = GameObject.Find("FaMen5").GetComponent<HighlightEffect>();//13.实例化截止阀门3高亮模块
        objectHighlight[6] = GameObject.Find("MainOpen").GetComponent<HighlightEffect>();//6.实例化总电源 开 高亮模块
        objectHighlight[7] = GameObject.Find("HeatingOpen").GetComponent<HighlightEffect>();//7.实例化加热电源 开 高亮模块
        objectHighlight[8] = GameObject.Find("FanOpen").GetComponent<HighlightEffect>();//8.实例化风机电源 开 高亮模块
        objectHighlight[9] = GameObject.Find("HeatingSwitch").GetComponent<HighlightEffect>();//9.实例化加热电源  关  高亮模块
        objectHighlight[10] = GameObject.Find("FanSwitch").GetComponent<HighlightEffect>();//10.实例化风机电源  关  高亮模块
        objectHighlight[11] = GameObject.Find("MainSwitch").GetComponent<HighlightEffect>();//11.实例化总电源高亮模块
        //步骤外的部分
        objectHighlight[12] = GameObject.Find("FaMen3").GetComponent<HighlightEffect>();//12.实例化截止阀门1高亮模块  
        objectHighlight[13] = GameObject.Find("FireExtinguisher").GetComponent<HighlightEffect>();//14.实例化灭火器高亮模块 
        objectHighlight[14] = GameObject.Find("ColdAirInletTemperature").GetComponent<HighlightEffect>();
        objectHighlight[15] = GameObject.Find("Trash").GetComponent<HighlightEffect>();//垃圾桶
        //显示屏
        objectHighlight[16] = GameObject.Find("GuanBiTemperaturePanel").GetComponent<HighlightEffect>();//管壁温度
        objectHighlight[17] = GameObject.Find("KongBanPressurePanel").GetComponent<HighlightEffect>();
        objectHighlight[18] = GameObject.Find("HeaterVoltagePanel").GetComponent<HighlightEffect>();
        objectHighlight[19] = GameObject.Find("FrequencyChangerPanel").GetComponent<HighlightEffect>();
        objectHighlight[20] = GameObject.Find("AirInPanel").GetComponent<HighlightEffect>();
        objectHighlight[21] = GameObject.Find("AirOutPanel").GetComponent<HighlightEffect>();
        objectHighlight[22] = GameObject.Find("HotAirInPanel").GetComponent<HighlightEffect>();
        objectHighlight[23] = GameObject.Find("HotAirOutPanel").GetComponent<HighlightEffect>();

        //实例化射线检测模块
        raycast = GameObject.Find("FirstPersonCharacter").GetComponent<Raycast>();
        //结束后弹出总结菜单
        gamingSummary = GameObject.Find("summary").GetComponent<RectTransform>();
        gamingSummary.DOAnchorPosX(0, 0.7f).SetId("gamingSummary").SetAutoKill(false);
        enableFPS = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        //等待五分钟
        wait5Mints = GameObject.Find("PercentText").GetComponent<Wait5Mins>();
        m_wait5Mints = GameObject.Find("Wait5Mins").GetComponent<RectTransform>();
        m_wait5Mints.anchoredPosition3D = new Vector3(500, 177, 0);
        //修改材质
        fanOpen = GameObject.Find("FanOpen").GetComponent<MeshRenderer>();
        fanSwitch = GameObject.Find("FanSwitch").GetComponent<MeshRenderer>();
        heatingOpen = GameObject.Find("HeatingOpen").GetComponent<MeshRenderer>();
        heatingSwitch = GameObject.Find("HeatingSwitch").GetComponent<MeshRenderer>();
        mainOpen = GameObject.Find("MainOpen").GetComponent<MeshRenderer>();
        mainSwitch = GameObject.Find("MainSwitch").GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            switch (inputF)
            {
                case 1://打开电闸
                    {
                        if (isdianzha == false && procedure[0] == false)
                        {
                            Text1.SetActive(false);
                            Text2.SetActive(true );
                            m_ElectricSwitch.OpenControl();
                            isdianzha = true;
                            procedure[1] = true;
                            //材质球变色
                            mainSwitch.material = red;
                            fanSwitch.material = red;
                            heatingSwitch.material = red;
                            
                        }
                        else if (isdianzha == true && procedure[15] == true)
                        {
                            m_ElectricSwitch.Close();
                            procedure[16] = true;
                            Text16.SetActive(false);
                            //弹出实验总结
                            DOTween.Restart("gamingSummary");
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            enableFPS.enabled = false;
                            //材质球变色
                            mainSwitch.material = normal;
                            fanSwitch.material = normal;
                            heatingSwitch.material = normal;
                        }
                        break;
                    }
                   //检查水箱 
                case 2://打开旁路阀门
                    {
                        if (ispanglufamen == false && procedure[1] == true)
                        {
                            Text2.SetActive(false );
                            Text3.SetActive(true);
                            m2_FaMenRotate.RotateControl(); //开旁路阀门
                            procedure[2] = true;
                            ispanglufamen = true;
                        }
                        
                        else if (ispanglufamen == true && procedure[8] ==true) 
                        {
                            if (temp <= 2160)
                            {
                                procedure[9] = true; 
                                procedure[8] = false;
                                Text9.SetActive(false);
                                Text10.SetActive(true);
                            }
                            else
                            {
                                temp -= 180;
                                m_KongBanPressure.KongBanYaCha();
                                m2_FaMenRotate.Close();//调小旁路阀门
                                //等待五分钟
                                m_wait5Mints.anchoredPosition3D = new Vector3(-865, 177, 0);
                                wait5Mints.Wait5MinsFun();
                                StartCoroutine(IEWait5Mins());
                            }
                        }
                            break;
                    }
                case 3://打开空气进口阀门
                   {
                        if (kongqijinkoufamen == false && procedure[2] == true)
                        {
                            Text3.SetActive(false);
                            Text4.SetActive(true);
                            m1_FaMenController.InControl();
                            kongqijinkoufamen = true;
                            procedure[3] = true;
                        }
                        else if (kongqijinkoufamen == true&& procedure[12] == true)
                        {
                            Text13.SetActive(false);
                            Text14.SetActive(true);
                            m1_FaMenController.InClose();
                            procedure[13] = true;
                        }

                        break;
                    }
                    
                case 4://打开空气出口阀门
                    {
                        if (kongqichukoufamen == false && procedure[3] == true )
                        {
                            Text4.SetActive(false);
                            Text5.SetActive(true);
                            m2_FaMenController.OutControl();
                            kongqichukoufamen = true;
                            procedure[4] = true;
                        }
                        else if (kongqichukoufamen == true && procedure[13] == true)
                        {
                            Text14.SetActive(false);
                            Text15.SetActive(true);
                            m2_FaMenController.OutClose();
                            procedure[14] = true;
                        } 
                        break;
                    }
                case 5://打开蒸汽进口阀门
                    {
                        if (zhenqijinkoufamen == false && procedure[4] == true)
                        {
                            Text5.SetActive(false);
                            Text6.SetActive(true);
                            m3_FaMenRotate.RotateControl();
                            zhenqijinkoufamen = true;
                            procedure[5] = true;
                        }
                        else if (zhenqijinkoufamen == true&& procedure[14] == true)
                        {
                            Text15.SetActive(false);
                            Text16.SetActive(true);
                            m3_FaMenRotate.Close();
                            procedure[15] = true;
                        }
                        break;
                    }
                case 6://打开总开关
                    {
                        if(zongkaiguan == false && procedure[5] == true)
                        {
                            Text6.SetActive(false);
                            Text7.SetActive(true);
                            m_MainOpen.MainOpenControl();
                            zongkaiguan = true;
                            procedure[6] = true;
                            //打开总开关后的一系列示数
                            FrequencyChanger.SetActive(true);
                            HeaterVoltage.SetActive(true);
                            m_GuanBiTemperature.GuanBiWenDu();
                            m_AirIn.ShiWen1 ();
                            m_AirOut.ShiWen2 ();
                            m_KongBanPressure.KongBan();
                            m_HotAirIn.ShiWen3 ();
                            m_HotAirOut.ShiWen4 ();

                            //材质球变色      
                            mainSwitch.material = normal;
                            mainOpen.material = green;
                        }
                        break;
                    }
                case 7://打开加热开关
                    {
                        if(jiarekaiguan == false && procedure[6] == true)
                        {
                            Text7.SetActive(false);
                            Text8.SetActive(true);
                            m_HeatingOpen.HeatingOpenControl();
                            jiarekaiguan = true;
                            procedure[7] = true;
                            //等待五分钟
                            m_wait5Mints.anchoredPosition3D = new Vector3(-865, 177, 0);
                            wait5Mints.Wait5MinsFun();
                            StartCoroutine(IEWait5Mins());

                            (HeaterVoltage).GetComponent<TMP_Text>().text = ("180V");
                            m_AirIn.KongQiJinKou();
                            m_AirOut.KongQiChuKou();
                            m_KongBanPressure.KongBan();
                            m_HotAirIn.renjinkou();
                            m_HotAirOut.rechukou();
                            m_GuanBiTemperature.guanbi();
                            //材质球变色
                            heatingSwitch.material = normal;
                            heatingOpen.material = green;
                        }
                       
                        break;
                    }
                case 8://打开风机
                    {
                        if (fengji ==false && procedure[7] == true) 
                        {
                            Text8.SetActive(false);
                            Text9.SetActive(true);
                            m_FanOpen.FanOpenControl();
                            fengji = true;
                            procedure[8] = true;
                            (FrequencyChanger).GetComponent<TMP_Text>().text = ("35Hz");
                            m_KongBanPressure.KongBanYaCha();
                            //等待五分钟
                            m_wait5Mints.anchoredPosition3D = new Vector3(-865, 177, 0);
                            wait5Mints.Wait5MinsFun();
                            StartCoroutine(IEWait5Mins());
                            //材质球变色
                            fanSwitch.material = normal;
                            fanOpen.material = green;
                        }
                        break;
                    }
                case 9://关闭加热开关
                    {
                        if (guanbijiarekaiguan == false && procedure[9] == true)
                        {
                            Text10.SetActive(false);
                            Text11.SetActive(true);
                            m_HeatingSwitch.HeatingSwitchControl();
                            guanbijiarekaiguan = true;
                            procedure[10] = true;
                            Debug.Log(procedure [9]);
                            (HeaterVoltage).GetComponent<TMP_Text>().text = ("0V");

                            m_GuanBiTemperature.GuanBiWenDu();
                            m_AirIn.ShiWen1();
                            m_AirOut.ShiWen2();
                           
                            m_HotAirIn.ShiWen3();
                            m_HotAirOut.ShiWen4();
                            //等待五分钟
                            m_wait5Mints.anchoredPosition3D = new Vector3(-865, 177, 0);
                            wait5Mints.Wait5MinsFun();
                            StartCoroutine(IEWait5Mins());
                            //材质球变色
                            heatingSwitch.material = red;
                            heatingOpen.material = normal;
                        }
                        break;
                    }
                case 10://关闭风机
                    {
                        if (guanbifengji == false && procedure[10]== true)
                        {
                            Text11.SetActive(false);
                            Text12.SetActive(true);
                            m_FanSwitch.FanSwitchControl();
                            guanbifengji = true;
                            procedure[11] = true;
                            (FrequencyChanger).GetComponent<TMP_Text>().text = ("0Hz");
                            m_KongBanPressure.KongBan();
                            //等待五分钟
                            m_wait5Mints.anchoredPosition3D = new Vector3(-865, 177, 0);
                            wait5Mints.Wait5MinsFun();
                            StartCoroutine(IEWait5Mins());
                            //材质球变色
                            fanSwitch.material = red;
                            fanOpen.material = normal;
                        }
                        break;
                    }
                case 11://关闭总电源
                    {
                        if (guanbizongkaiguan == false&& procedure[11] == true)
                        {
                            Text12.SetActive(false);
                            Text13.SetActive(true);
                            m_MainSwitch.MainSwitchControl();
                            guanbizongkaiguan = true;
                            procedure[12] = true;

                            FrequencyChanger.SetActive(false);
                            HeaterVoltage.SetActive(false);
                            KongBanPressure.KongBanPressure.gameObject.SetActive(false);
                            GuanBiTemperature.GuanBiTemperature.gameObject.SetActive(false);
                            AirIn.AirIn.gameObject.SetActive(false);
                            AirOut.AirOut.gameObject.SetActive(false);
                            HotAirIn.HotAirIn.gameObject.SetActive(false);
                            HotAirOut.HotAirOut.gameObject.SetActive(false);
                            //材质球变色
                            mainSwitch.material = red;
                            mainOpen.material = normal;
                        }
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
    /// <summary>
    /// 在Trigger内触发UI提示
    /// </summary>
    /// <param name="other">触发的物体</param>
    private void OnTriggerStay(Collider other)
    {
        if (raycast.TarRaycast() && other.gameObject.name == raycast.targetTransform.name)
        {
            switch (other.gameObject.name)
            {
                case "ElectricSwitch"://1打开电闸
                    {
                        uiObjectInformation.text = "电闸";
                        uiTips.text = "按“F”打开";
                        objectHighlight[0].highlighted = true;
                        inputF = 1;
                        break;
                    }
                
                case "WaterTank"://2检查水箱
                    {
                        uiObjectInformation.text = "水箱";
                        uiTips.text = "水深约2/3";
                        objectHighlight[1].highlighted = true;
                       
                        break;
                    }
                case "FaMen4"://3开旁路阀门
                    {
                      
                        uiObjectInformation.text = "旁路阀门";
                        uiTips.text = "按“F”打开" ;
                        objectHighlight[2].highlighted = true;
                        inputF = 2;
                        break;
                    }
                case "FaMen1"://4打开空气进口阀
                    {
                        uiObjectInformation.text = "冷空气进口阀门";
                        uiTips.text = "按“F”打开";
                        objectHighlight[3].highlighted = true;
                        inputF = 3;
                        break;
                    }
                case "FaMen2"://5打开空气出口阀门
                    {
                        uiObjectInformation.text = "冷空气出口阀门";
                        uiTips.text = "按“F”打开";
                        objectHighlight[4].highlighted = true;
                        inputF = 4;
                        break;
                    }
                case "FaMen5"://6打开蒸汽进口阀门
                    {
                        uiObjectInformation.text = "蒸汽进口阀门";
                        uiTips.text = "按“F”打开" ;
                        objectHighlight[5].highlighted = true;
                        inputF = 5;
                        break;
                    }
                case "MainOpen"://7打开总电源
                    {
                        uiObjectInformation.text = "总电源-开";
                        uiTips.text = "按“F”打开";
                        objectHighlight[6].highlighted = true;
                        inputF = 6;
                        break;
                    }
                    //调整电压后打开加热电源（电压默认）
                case "HeatingOpen"://8打开加热电源
                    {
                        uiObjectInformation.text = "加热电源-开";
                        uiTips.text = "按“F”打开";
                        objectHighlight[7].highlighted = true;
                        inputF =7;
                        break;
                    }
                case "FanOpen"://9启动风机
                    {
                        uiObjectInformation.text = "风机电源-开";
                        uiTips.text = "按“F”打开";
                        objectHighlight[8].highlighted = true;
                        inputF = 8;
                        break;
                    }

                    //调小旁路阀门

                case "HeatingSwitch"://关闭加热开关
                    {
                        uiObjectInformation.text = "加热电源-关";
                        uiTips.text = "按“F”关闭";
                        objectHighlight[9].highlighted = true;
                        inputF = 9;
                        break;
                    }
                case "FanSwitch"://关闭风机
                    {
                        uiObjectInformation.text = "风机电源-关";
                        uiTips.text = "按“F”关闭";
                        objectHighlight[10].highlighted = true;
                        inputF = 10;
                        break;
                    }
                case "MainSwitch"://关闭总电源
                    {
                        uiObjectInformation.text = "总电源-关";
                        uiTips.text = "按“F”关闭";
                        objectHighlight[11].highlighted = true;
                        inputF = 11;
                        break;
                    }
              /******************************************************************/ 

                case "FaMen3"://不用动
                    {
                        uiObjectInformation.text = "截止阀门";
                        uiTips.text = "";
                        objectHighlight[12].highlighted = true;
                        break;
                    }

                case "FireExtinguisher":
                    {
                        uiObjectInformation.text = "灭火器";
                        uiTips.text = "";
                        objectHighlight[13].highlighted = true;                        
                        break;
                    }
                case "Trash":
                    {
                        uiObjectInformation.text = "垃圾桶";
                        uiTips.text = "";
                        objectHighlight[14].highlighted = true;                        
                        break;
                    }
                case "ColdAirInletTemperature":
                    {
                        uiObjectInformation.text = "空气进口温度";
                        uiTips.text = "20℃";
                        objectHighlight[15].highlighted = true;                      
                        break;
                    }
                /*********************************************************************************/
                case "GuanBiTemperaturePanel":
                    {
                        uiObjectInformation.text = "管壁面温度";
                        uiTips.text = "";
                        objectHighlight[16].highlighted = true;
                        break;
                    }
                case "KongBanPressurePanel":
                    {
                        uiObjectInformation.text = "孔板压差";
                        uiTips.text = "";
                        objectHighlight[17].highlighted = true;
                        break;
                    }
                case "HeaterVoltagePanel":
                    {
                        uiObjectInformation.text = "加热电压";
                        uiTips.text = "";
                        objectHighlight[18].highlighted = true;
                        break;
                    }
                case "FrequencyChangerPanel":
                    {
                        uiObjectInformation.text = "变频器";
                        uiTips.text = "";
                        objectHighlight[19].highlighted = true;
                        break;
                    }
                case "AirInPanel":
                    {
                        uiObjectInformation.text = "空气进口温度";
                        uiTips.text = "";
                        objectHighlight[20].highlighted = true;
                        break;
                    }
                case "AirOutPanel":
                    {
                        uiObjectInformation.text = "空气出口温度";
                        uiTips.text = "";
                        objectHighlight[21].highlighted = true;
                        break;
                    }
                case "HotAirInPanel":
                    {
                        uiObjectInformation.text = "热蒸汽进口温度";
                        uiTips.text = "";
                        objectHighlight[22].highlighted = true;
                        break;
                    }
                case "HotAirOutPanel":
                    {
                        uiObjectInformation.text = "热蒸汽出口温度";
                        uiTips.text = "";
                        objectHighlight[23].highlighted = true;
                        break;
                    }
             
                default:
                    {
                        uiTips.text = null;
                        uiObjectInformation.text = null;
                        for (int i = 0;i < quantityHighlight;i++)
                        {
                            objectHighlight[i].highlighted = false;
                        }
                        break;
                    }
            }
        }
    }
    IEnumerator IEWait5Mins()
    {
        yield return new WaitForSecondsRealtime(6);
        m_wait5Mints.anchoredPosition3D = new Vector3(500, 177, 0);
    }

}
