using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTips : MonoBehaviour
{
    private Text[] tips;

    private CanvasGroup canvasGroup;

    private float targetAlpha = 0;
    private float smoothing = 5;

    void Start()
    {

        canvasGroup = transform.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }
    private void Update()
    {
        if (canvasGroup != null && canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - targetAlpha) < 0.02f)
            {
                canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public virtual void Show()
    {
        canvasGroup.blocksRaycasts = true;
        targetAlpha = 1;
    }
    public virtual void Hide()
    {
        canvasGroup.blocksRaycasts = false;
        targetAlpha = 0;
    }
    public virtual void Toggle()
    {
        if (targetAlpha == 0)
        {
            Show();
        }
        else if (targetAlpha == 1)
        {
            Hide();
        }
    }

    public void Init()
    {
        tips = transform.GetComponentsInChildren<Text>();
    }

    public void SetText(Animal animal)
    {
        tips[0].text = string.Format("编码：{0}", animal.编码);
        tips[1].text = string.Format("物种：{0}", animal.种类);
        tips[2].text = string.Format("品种：白兔");
        tips[3].text = string.Format("年龄：{0}天", animal.年龄);
        tips[4].text = string.Format("寿命：{0}天", animal.寿命);
        tips[5].text = string.Format("当前状态：{0}", animal.当前状态);
        tips[6].text = string.Format("身高：{0:N2}cm", animal.身高);
        tips[7].text = string.Format("体重：{0:N2}kg", animal.体重);
        tips[8].text = string.Format("胸围：{0:N2}cm", animal.胸围);
        tips[9].text = string.Format("腰围：{0:N2}cm", animal.腰围);
        tips[10].text = string.Format("臀围：{0:N2}cm", animal.臀围);
        tips[11].text = string.Format("发育期：{0}天", animal.发育期);
        tips[12].text = string.Format("妊娠期：{0}天", animal.妊娠期);
        tips[13].text = string.Format("魅力值：{0:N0}", animal.魅力值);
        tips[14].text = string.Format("消耗食物速度：{0}", animal.消耗食物速度);
    }
    public void SetLocalPostion(Vector3 position)
    {
        transform.localPosition = position;
    }
}