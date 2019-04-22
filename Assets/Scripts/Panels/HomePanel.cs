using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : BuildingPanel
{
    private Transform messages;
    private List<Message> messageList;

    private Button nextDay;

    public override void Start()
    {
        base.Start();
        messages = transform.Find("Messages");
        messageList = new List<Message>();
        nextDay = transform.Find("Next").GetComponent<Button>();
        foreach (Transform item in messages)
        {
            messageList.Add(item.GetComponent<Message>());
        }

        nextDay.onClick.AddListener(NextDay);
    }

    public override void Show()
    {
        base.Show();
    }

    public void SetMessage2List(PlayerBaseProperty playerBase) //目前只有Base
    {
        title.text = string.Format(playerBase.PlayerName + "的研究所");

        messageList[0].SetMessage("姓名", playerBase.PlayerName);
        messageList[1].SetMessage("精力", string.Format("{0}/{1}", playerBase.CurrentEnergy, playerBase.MaxEnergy));
        messageList[2].SetMessage("资产", playerBase.CoinCount.ToString());
        messageList[3].SetMessage("经营天数", playerBase.PlayDays.ToString());
        messageList[4].SetMessage("个体总数", playerBase.AnimalCount.ToString());
        messageList[5].SetMessage("利润", playerBase.EarnCoin.ToString());
        messageList[6].SetMessage("作物总数", playerBase.CropCount.ToString());
    }

    public void NextDay()
    {

    }
}
