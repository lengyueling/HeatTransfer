using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionText : MonoBehaviour
{
    Text tips;
    Text data;
    int num;
    private void Start()
    {
        num = (int)Random.Range(0, 15);
        //data = GameObject.Find("Data").GetComponent<Text>();
        tips = GameObject.Find("Tips").GetComponent<Text>();
    }
    private void Update()
    {
        //Data();
        Tips();
    }
    //void Data()
    //{
    //    data.text = "环境温度：24.7℃ " +
    //        "环境大气压：1.03Kpa " +
    //        "内管内径：0.02m " +
    //        "内管外径：0.022m " +
    //        "测量段长度：1.2m " +
    //        "孔板流量计孔径：0.017m " +
    //        "管道材质：紫铜内管 " +
    //        "强化管：否 " +
    //        "加热流体：水 " +
    //        "操作电压：180V " +
    //        "操作电流：10A " +
    //        "变频器频率：35HZ";
    //}
    void Tips()
    {
        switch (num)
        {
            case 1:
                {
                    tips.text = "露点：空气的相对湿度变成100%时，即实际水蒸汽压力等于饱和水蒸气压强的温度";
                    break;
                }
            case 2:
                {
                    tips.text = "泡点：液体混合物处于某一压力下，开始从液相中分离出第一批气泡的温度。";
                    break;
                }
            case 3:
                {
                    tips.text = "气缚：若在叶轮内充满空气的条件下启动，因为空气密度小，高速短短的空气未能在泵的进出口间形成足够大的静压差，一直泵内气体排不掉，低于泵的液体又吸不上来的现象。";
                    break;
                }
            case 4:
                {
                    tips.text = "气蚀：当液体在固体表面接触时的压力低于它的蒸气压，将在固体表面附近形成气泡，气泡流动到液体压力超过气体压力的地方，气泡破裂产生极大的冲击力和高温，破坏叶轮的现象。";
                    break;
                }
            case 5:
                {
                    tips.text = "泡点：液体混合物处于某一压力下，开始从液相中分离出第一批气泡的温度。";
                    break;
                }
            case 6:
                {
                    tips.text = "当量直径=四倍的水力半径";
                    break;
                }
            case 7:
                {
                    tips.text = "泡点：液体混合物处于某一压力下，开始从液相中分离出第一批气泡的温度。";
                    break;
                }
            case 8:
                {
                    tips.text = "相律:自由度=组分数-相数+2";
                    break;
                }
            case 9:
                {
                    tips.text = "吸收机理的三个模型:双膜论，溶质渗透模型，表面更新模型";
                    break;
                }
            case 10:
                {
                    tips.text = "筛板的板面分布:有效传质区，降液区，入口安定区，出口安定区，边缘固定区";
                    break;
                }
            case 11:
                {
                    tips.text = "湿度，表示湿空气中水汽含量的参量，定义为空气中单位质量绝干空气所含有的水汽质量";
                    break;
                }
            case 12:
                {
                    tips.text = "相对湿度，在一定的总压下，湿空气中水蒸气分压与同温度下湿空气中水汽分压可能达到最大值之比";
                    break;
                }
            default:
                {
                    tips.text = "闪点：可燃液体性质的指标之一，是液体表面上的蒸气和空气的混合物与火接触面初次发生蓝色火焰闪光时的温度。";
                    break;
                }
        }
    }
}
