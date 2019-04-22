using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBuilding : Building
{
    private Vector2 toolTipPositionOffset = new Vector2(90, -120);
    private List<AnimalJson> normalAnimals;
    private AnimalTips animalTips;
    private bool isAnimalTipsShow = false;
    private Canvas canvas;

    private void Start()
    {
        ParseItemJson();
        animalTips = GameObject.Find("Canvas").transform.Find("AnimalTips").GetComponent<AnimalTips>();
        canvas = GameObject.Find("Canvas").transform.GetComponent<Canvas>();
        animalTips.Init();
    }
    private void Update()
    {
        if (isAnimalTipsShow)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            animalTips.SetLocalPostion(position + toolTipPositionOffset);
        }
    }


    void ParseItemJson()
    {
        normalAnimals = new List<AnimalJson>();
        TextAsset animalText = Resources.Load<TextAsset>("animals");
        string animalJson = animalText.text;
        JSONObject animalObject = new JSONObject(animalJson);

        foreach (JSONObject temp in animalObject.list)
        {
            string kind = temp["kind"].str;
            int age = (int)temp["age"].n;
            float height = temp["height"].n;
            float weight = temp["weight"].n;
            float xiong = temp["xiong"].n;
            float yao = temp["yao"].n;
            float tun = temp["tun"].n;
            int fayu = (int)temp["fayu"].n;
            int renshen = (int)temp["renshen"].n;
            string food = temp["food"].str;
            int feed = (int)temp["feed"].n;

            AnimalJson animal = new AnimalJson(kind, age, height, weight, xiong, yao, tun, fayu, renshen, food, feed);
            normalAnimals.Add(animal);
        }
    }

    public void ShowAnimalTips(Animal animalShow)
    {
        if (this.isAnimalTipsShow) return;
        //Debug.Log(isAnimalTipsShow);
        isAnimalTipsShow = true;
        animalTips.Show();
        animalTips.SetText(BuildAnimal(AnimalKind.兔娘, 0, 0));
    }
    public void HideAnimalTips()
    {
        isAnimalTipsShow = false;
        Debug.Log(isAnimalTipsShow);
        animalTips.Hide();
    }  

    public Animal BuildAnimal(AnimalKind kind, int change, int lastNum, Animal mother = null)
    {
        Animal returnAnimal = new Animal();

        if (mother == null)
        {
            //以标准为基准随机生成
            foreach (AnimalJson animal in normalAnimals)
            {
                if (kind.ToString() == animal.Kind)
                {
                    returnAnimal.编码 = (010100 + lastNum + 1).ToString("000000");
                    returnAnimal.种类 = kind;
                    returnAnimal.当前状态 = CurrentState.发育中;
                    returnAnimal.年龄 = 1;

                    float randomHeight = Random.Range(-5.00f, +5.00f);
                    returnAnimal.身高 = animal.Height + randomHeight;

                    float chaZhi = 0;

                    float randomXiong = Random.Range(-5.00f, +5.00f);
                    returnAnimal.胸围 = returnAnimal.身高 * 0.51f + randomXiong;
                    chaZhi += randomXiong;

                    float randomYao = Random.Range(-5.00f, +5.00f);
                    returnAnimal.腰围 = returnAnimal.身高 * 0.34f + randomYao;
                    chaZhi += randomYao;

                    float randomTun = Random.Range(-5.00f, +5.00f);
                    returnAnimal.臀围 = returnAnimal.身高 * 0.54f + randomTun;
                    chaZhi += randomTun;

                    float randomWeight = Random.Range(-5.00f, +5.00f);
                    randomWeight += chaZhi;
                    returnAnimal.体重 = (returnAnimal.身高 - 70) * 0.6f + randomWeight;

                    returnAnimal.寿命 = animal.Age + (int)chaZhi;

                    int fayuChaZhi = (int)((5 - randomXiong) / 2);
                    returnAnimal.发育期 = animal.FaYu + fayuChaZhi;

                    int renshenChaZhi = (int)((5 - randomTun) / 2);
                    returnAnimal.妊娠期 = animal.RenShen + renshenChaZhi;

                    int feedChaZhi = (int)((5 - randomYao) / 2);
                    returnAnimal.妊娠期 = Mathf.Max(1, animal.RenShen - renshenChaZhi);

                    returnAnimal.魅力值 = Mathf.Max(30, (100 - Mathf.Abs(chaZhi) * 10));

                    returnAnimal.食物种类 = (FeedFood)(System.Enum.Parse(typeof(FeedFood), animal.Food));
                    returnAnimal.消耗食物速度 = Mathf.Max(1, (animal.Feed + (int)randomWeight / 3));
                }
            }
        }

        return returnAnimal;
    }

    AnimalJson FindAnimalJsonByKind(AnimalKind kind)
    {
        AnimalJson returnJson = new AnimalJson();

        foreach (AnimalJson item in normalAnimals)
        {
            if (kind.ToString() == item.Kind)
            {
                returnJson = item;
            }
        }
        return returnJson;
    }
}
