using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceManager : MonoBehaviour
{
    public enum Type {Head, Armor, Hammer, Gun }
    public Type type;
    //�÷��̾� ��ȭ ���� �ҷ�����
    public int Level;
    public int gold;
    public int PlusStat; // ��ȭ�� ���ȼ�ġ
    public int PlusHand;
    public int PlusSub;
    public int Probability; // Ȯ��
    public bool isGun;

    public Text LvText;
    public Text Stat;
    public Text Consumgold;
    public Text TalkText;

    void Start()
    {
        Level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Enhance(Level);
        LvText.text = "Lv." + Level;
        if (isGun)
            Stat.text = "+ " + PlusHand + " & + " + PlusSub;
        else
            Stat.text = "+ " + PlusStat;
        Consumgold.text = gold.ToString();
    }

    public void EnhanceBtnClick()
    {
        Player player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        if(player.coin < gold)
        {
            TalkText.text = "���� ���� ���� ������!";
        }
        else
        {
            player.coin -= gold;
            int random = Random.Range(0, 101);
            if (Probability > random)
            {
                TalkText.text = "������! ��ȭ�� �����߾�!";
                Level++;
                switch (type)
                {
                    case Type.Head:
                        player.maxhealth += 10;
                        PlusStat += 10;
                        break;
                    case Type.Armor:
                        player.defens += 1;
                        PlusStat += 1;
                        break;
                    case Type.Hammer:
                        GameObject.Find("Weapon Point").transform.GetChild(0).gameObject.GetComponent<Weapon>().damage += 3;
                        PlusStat += 3;
                        break;
                    case Type.Gun:
                        GameObject.Find("Weapon Point").transform.GetChild(1).gameObject.GetComponent<Weapon>().damage += 2;
                        PlusHand += 2;
                        GameObject.Find("Weapon Point").transform.GetChild(2).gameObject.GetComponent<Weapon>().damage += 1;
                        PlusSub += 1;
                        break;
                }
            }
            else
            {
                TalkText.text = "�ƽ��� ��ȭ�� �����߾�...";
            }
        }
        
    }

    public void Enhance(int level)
    {
        switch(level)
        {
            case 0:
                gold = 500;
                Probability = 100;
                break;
            case 1:
                gold = 100;
                Probability = 75;
                break;
            case 2:
                gold = 1500;
                Probability = 60;
                break;
            case 3:
                gold = 2000;
                Probability = 50;
                break;
            case 4:
                gold = 2500;
                Probability = 40;
                break;
            case 5:
                gold = 3000;
                Probability = 30;
                break;
            case 6:
                gold = 3500;
                Probability = 25;
                break;
            case 7:
                gold = 4000;
                Probability = 20;
                break;
            case 8:
                gold = 4500;
                Probability = 15;
                break;
            case 9:
                gold = 5000;
                Probability = 10;
                break;
            case 10:
                gold = 5500;
                Probability = 5;
                break;
        }
    }
}