using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{

    //3D字体面板控制
    //3D字体
    private TextMeshPro KongBanPressure;
    private TextMeshPro GuanBiTemperature;
    private TextMeshPro AirIn;
    private TextMeshPro AirOut;
    private TextMeshPro HotAirIn;
    private TextMeshPro HotAirOut;
    private TextMeshPro HeaterVoltage;
    private TextMeshPro FrequencyChanger;

    void Awake()
    {
        //3D字体
        KongBanPressure = GameObject.Find("KongBanPressure").GetComponent<TextMeshPro>();//孔板压差TMP
        GuanBiTemperature = GameObject.Find("GuanBiTemperature").GetComponent<TextMeshPro>();//管壁温度TMP
        AirIn = GameObject.Find("AirIn").GetComponent<TextMeshPro>();//空气进口温度TMP
        AirOut = GameObject.Find("AirOut").GetComponent<TextMeshPro>();//空气出口温度TMP
        HotAirIn = GameObject.Find("HotAirIn").GetComponent<TextMeshPro>();//热蒸汽进口温度TMP
        HotAirOut = GameObject.Find("HotAirOut").GetComponent<TextMeshPro>();//热蒸汽出口温度TMP
        HeaterVoltage = GameObject.Find("HeaterVoltage").GetComponent<TextMeshPro>();//加热电压TMP
        FrequencyChanger = GameObject.Find("FrequencyChanger").GetComponent<TextMeshPro>();//变频器TMP
    }
}
