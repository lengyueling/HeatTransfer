using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    public Text colorChange;
    public RectTransform gameMenuMove;
    public Transform notebookRotation;
    FunctionCalculation functionCalculation;
    private void Start()
    {
        Cursor.visible = false;//隐藏鼠标
        functionCalculation = GameObject.Find("FunctionCalculation").GetComponent<FunctionCalculation>();
        DontDestroyOnLoad(functionCalculation);//切换场景不删除

        colorChange = gameObject.GetComponent<Text>();
        colorChange.DOColor(new Color(0.9f, 0.9f, 0.9f, 0.1960784f), 2).SetId("colorChange").SetAutoKill(false).SetLoops(-1);

        gameMenuMove = GameObject.Find("MainMenu").GetComponent<RectTransform>();
        gameMenuMove.DOLocalMoveX(0, 0.5f).SetId("gameMenuMove").SetAutoKill(false);
        notebookRotation = GameObject.Find("notepad_top").GetComponent<Transform>();
        notebookRotation.DOLocalRotate(new Vector3(0, 0, -180), 2).SetId("notebookRotation").SetAutoKill(false);
        DOTween.Pause("gameMenuMove");
        DOTween.Pause("notebookRotation");
        
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            DOTween.PlayForward("gameMenuMove");
            DOTween.PlayForward("notebookRotation");
            gameObject.SetActive(false);
            Cursor.visible = true;//显示鼠标
        }
    }
}
