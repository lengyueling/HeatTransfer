using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class FunctionCalculation : MonoBehaviour
{
    /// <summary>
    /// 阀门开度
    /// </summary>
    public double Theta;
    /// <summary>
    /// 气体流量
    /// </summary>
    static double V;
    /// <summary>
    /// 孔板压差
    /// </summary>
    static double DeltaP;
    /// <summary>
    /// 流速
    /// </summary>
    static double u0;
    /// <summary>
    /// 定性温度
    /// </summary>
    static double tm;
    /// <summary>
    /// 动力粘度
    /// </summary>
    static double Mu;
    /// <summary>
    /// 密度
    /// </summary>
    static double Rho;
    /// <summary>
    /// 雷诺数
    /// </summary>
    static double Re;
    /// <summary>
    /// 热导率
    /// </summary>
    static double Lambada;
    /// <summary>
    /// 比热容
    /// </summary>
    static double Cp;
    /// <summary>
    /// 普朗特数
    /// </summary>
    static double Pr;
    /// <summary>
    /// 给热系数
    /// </summary>
    static double Alphai;
    /// <summary>
    /// 空气出口温度
    /// </summary>
    public static double tco;
    /// <summary>
    /// 空气进口温度
    /// </summary>
    static double tci = 24.7;
    /// <summary>
    /// 内管外径
    /// </summary>
    static double d0 = 0.022;
    /// <summary>
    /// 内管直径
    /// </summary>
    static double di = 0.02;
    /// <summary>
    /// 对数平均直径
    /// </summary>
    static double dm;

    PlayerTrigger temp;

    public TextMeshPro GuanBiTemperature;
    public TextMeshPro AirIn;
    public TextMeshPro AirOut;
    public TextMeshPro KongBanPressure;
    public TextMeshPro HotAirIn;
    public TextMeshPro HotAirOut;

    //设置面板
    InputField huanjingwendu;
    InputField huanjingdaqiya;
    InputField caozuodianya;
    InputField caozuodianliu;
    InputField bianpinqipinlv;
    Dropdown neiguanneijing;
    Dropdown neiguanwaijing;
    Dropdown celiangduanchangdu;
    Dropdown kongbanliuliangjikongjing;
    Dropdown jiareliuti;
    Toggle qianghuaguan;
    double ambientTemperature;
    double ambientAtmosphericPressure;
    double internalDiameter;
    double externaDiameter;
    double lengthOfMeasuringSection;
    double apertureOfOrificeFlowmeter;
    double pipeMaterial;
    double strengtheningTube;
    double heatingFurnaceBody;
    double voltage;
    double electricCurrent;
    double frequencyconverter;

    //0管壁 1空气出口 2热空气入口 3热空气出口 4孔板压差
    public double[] temp1 = { 0, 0, 0, 0, 0, 0 };
    void Awake()
    {
        if ((SceneManager.GetActiveScene().name.Equals("GameInterface")))
        {
            temp = GameObject.Find("PlayerTrigger").GetComponent<PlayerTrigger>();
            GuanBiTemperature = GameObject.Find("GuanBiTemperature").GetComponent<TextMeshPro>();
            AirIn = GameObject.Find("AirIn").GetComponent<TextMeshPro>();
            AirOut = GameObject.Find("AirOut").GetComponent<TextMeshPro>();
            KongBanPressure = GameObject.Find("KongBanPressure").GetComponent<TextMeshPro>();
            HotAirIn = GameObject.Find("HotAirIn").GetComponent<TextMeshPro>();
            HotAirOut = GameObject.Find("HotAirOut").GetComponent<TextMeshPro>();
        }
        if ((SceneManager.GetActiveScene().name.Equals("StartInterface")))
        {
            huanjingwendu = GameObject.Find("huanjingwendu").GetComponent<InputField>();
            huanjingdaqiya = GameObject.Find("huanjingdaqiya").GetComponent<InputField>();
            caozuodianya = GameObject.Find("caozuodianya").GetComponent<InputField>();
            caozuodianliu = GameObject.Find("caozuodianliu").GetComponent<InputField>();
            bianpinqipinlv = GameObject.Find("bianpinqipinlv").GetComponent<InputField>();
            neiguanneijing = GameObject.Find("neiguanneijing").GetComponent<Dropdown>();
            neiguanwaijing = GameObject.Find("neiguanwaijing").GetComponent<Dropdown>();
            celiangduanchangdu = GameObject.Find("celiangduanchangdu").GetComponent<Dropdown>();
            kongbanliuliangjikongjing = GameObject.Find("kongbanliuliangjikongjing").GetComponent<Dropdown>();
            jiareliuti = GameObject.Find("jiareliuti").GetComponent<Dropdown>();
            qianghuaguan = GameObject.Find("qianghuaguan").GetComponent<Toggle>();
        }
    }
    
    public void Start()
    {
        Theta = 2880;
        V = 0.01391 - Theta * 0.00000765 + Math.Pow(Theta, 2) * 0.00000000152047;
        DeltaP = 60.52611 - V * 19282.49906 + Math.Pow(V, 2) * 29016200;
        u0 = 0.56308 + V * 4369.41367 + Math.Pow(V, 2) * 17593.65134;
        Alphai = -212.4015 + 18.76226 * tci - 0.19516 * Math.Pow(tci, 2);
        tco = 69.63304 - 0.06366 * Alphai + Math.Pow(Alphai, 2) * Math.Pow(16.484, -4);
        tm = (tci + tco) / 2;
        Mu = 0.000019;
        Rho = 1.29447 - 0.00466 * tm + Math.Pow(tm, 2) * Math.Pow(19.177, -5);
        dm = (d0 - di) / Math.Log10(d0 / di);
        Re = (dm * u0 * Rho) / Mu;
        Lambada = 0.02437 + 0.0000779509 * tm - Math.Pow(tm, 2) * 0.0000000144225;
        Cp = 1.005;
        Pr = (Cp * Mu) / Lambada;
        //Debug.Log("V"+V);
        //Debug.Log("DeltaP"+DeltaP);
        //Debug.Log("u0"+u0);
        //Debug.Log("tci"+tci);
        //Debug.Log("alphai"+Alphai);
        //Debug.Log("tco"+tco);
        //Debug.Log("mu"+Mu);
        //Debug.Log("rho"+Rho);
        //Debug.Log("dm"+dm);
        //Debug.Log("re"+Re);
        //Debug.Log("lambada"+Lambada);
        //Debug.Log("cp"+Cp);
        //Debug.Log("pr"+Pr);
    }
    private void Update()
    {
        //设置
        if ((UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("StartInterface")))
        {
            if (huanjingwendu.text != "")
            {
                tci = double.Parse(huanjingwendu.text);
            }
        }

    }
    
    //固定值
    public void ShiWen1()
    {
        AirIn.text = Math.Round(tci, 2).ToString();
    }
    bool kongqijinkouFlag = false;
    public void ShiWen2()
    {
        if (kongqijinkouFlag == true)
        {
            DOTween.To(() => temp1[1], x => temp1[1] = x, tci, 5).SetEase(Ease.Linear);
            StartCoroutine(IEChangeNumbers(1));
            return;
        }
        AirOut.text = tci.ToString();
        temp1[1] = tci;
        kongqijinkouFlag = true;
    }
    bool rejinkouFlag = false;
    public void ShiWen3()
    {
        if (rejinkouFlag == true)
        {
            DOTween.To(() => temp1[2], x => temp1[3] = x, tci, 5).SetEase(Ease.Linear);
            StartCoroutine(IEChangeNumbers(2));
            return;
        }
        HotAirIn .text = tci.ToString();
        temp1[2] = tci;
        rejinkouFlag = true;
    }
    bool rechukouFlag = false;
    public void ShiWen4()
    {
        if (rechukouFlag == true)
        {
            DOTween.To(() => temp1[3], x => temp1[3] = x, tci, 5).SetEase(Ease.Linear);
            StartCoroutine(IEChangeNumbers(3));
            return;
        }
        HotAirOut.text = tci.ToString();
        temp1[3] = tci;
        rechukouFlag = true;
    }
    bool kongbanFlag = false;
    public void KongBan()
    {
        if (kongbanFlag == true)
        {
            DOTween.To(() => temp1[4], x => temp1[4] = x, tci, 5).SetEase(Ease.Linear);
            StartCoroutine(IEChangeNumbers(4));
            return;
        }
        (KongBanPressure).GetComponent<TMP_Text>().text = Math.Round(0.0,2).ToString();
        temp1[4] =0;
        kongbanFlag = true;
    }
    public void renjinkou()
    {
        DOTween.To(() => temp1[2], x => temp1[2] = x, 97.4, 5).SetEase(Ease.Linear);
        StartCoroutine(IEChangeNumbers(2));
    }
    public void rechukou()
    {
        DOTween.To(() => temp1[3], x => temp1[3] = x, 94.2, 5).SetEase(Ease.Linear);
        StartCoroutine(IEChangeNumbers(3));
    }
    public void guanbi()
    {
        DOTween.To(() => temp1[0], x => temp1[0] = x, 94.2, 5).SetEase(Ease.Linear);
        StartCoroutine(IEChangeNumbers(0));
    }
    IEnumerator IEChangeNumbers(int tempMenber)
    {
        double timer = 0;
        while (timer <= 5)
        {
            switch (tempMenber)
            {
                case 0:
                    {
                        (GuanBiTemperature).GetComponent<TMP_Text>().text = Math.Round(temp1[0], 2).ToString();
                        break;
                    }
                case 1:
                    {
                        AirOut.text = Math.Round(temp1[1],2).ToString();
                        break;
                    }
                case 2:
                    {
                        (HotAirIn).GetComponent<TMP_Text>().text = Math.Round(temp1[2], 2).ToString();
                        break;
                    }
                case 3:
                    {
                        (HotAirOut).GetComponent<TMP_Text>().text = Math.Round(temp1[3], 2).ToString();
                        break;
                    }
                case 4:
                    {
                        KongBanPressure.text = Math.Round(temp1[4]).ToString();
                        break;
                    }
                case 5:
                    {
                        break;
                    }
            }
            yield return new WaitForSeconds(0.1f);
            timer += 0.1;
        }
    }
    /********************************************/
    //变化值
    bool guanbiFlag = false;
    public void GuanBiWenDu()
    {
        if (guanbiFlag == true)
        {
            DOTween.To(() => temp1[0], x => temp1[0] = x, tci, 5).SetEase(Ease.Linear);
            StartCoroutine(IEChangeNumbers(0));
            return;
        }
        GuanBiTemperature.text = tci.ToString();
        temp1[0] = tci;
        guanbiFlag = true;
    }
    public void KongQiJinKou()
    {
        AirIn.text = Math.Round(tci, 2).ToString();
    }

    public void KongQiChuKou()
    {
        DOTween.To(() => temp1[1], x => temp1[1] = x, tco, 5).SetEase(Ease.Linear);
        StartCoroutine(IEChangeNumbers(1));
    }
    public void KongBanYaCha()
    {
        V = 0.01391 - temp.temp * 0.00000765 + Math.Pow(temp.temp, 2) * 0.00000000152047;
        DeltaP = 60.52611 - V * 19282.49906 + Math.Pow(V, 2) * 29016200;
        DOTween.To(() => temp1[4], x => temp1[4] = x, DeltaP, 5).SetEase(Ease.Linear);
        StartCoroutine(IEChangeNumbers(4));
    }
    public void ReZhengQiJinKou()
    {
        HotAirIn.text = tco.ToString();
    }
    public void ReZhengQiChuKou()
    { 
        HotAirOut.text = tco.ToString();
    }
    
}
