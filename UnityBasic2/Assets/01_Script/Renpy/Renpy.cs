using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG; // 배경
    [SerializeField] Image[] img_Character; // 캐릭터

    [SerializeField] TextMeshProUGUI txt_Name; // 캐릭터 이름 : 호시노
    [SerializeField] TextMeshProUGUI txt_NameTitle; // 캐릭터 타이틀 : 대책위원회
    [SerializeField] TextMeshProUGUI txt_Dialogue; // 대사 : 여기에 대사가 출력됩니다.

    int id = 1;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void OnClickButton()
    {
        RefreshUI();
        id++;
    }

    public void RefreshUI()
    {
        int characterID = SData.GetDialogueData(id).Characterid;

        txt_Name.text = SData.GetCharacterData(10101).Name;
        txt_NameTitle.text = SData.GetCharacterData(10101).Title;
        txt_Dialogue.text = SData.GetDialogueData(id).Dialogue;

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).BG);
        for (int i = 0; i < img_Character.Length; i++)
        {
            if(i == SData.GetDialogueData(id).Position)
            {
                img_Character[i].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(characterID).Image);
                img_Character[i].gameObject.SetActive(true);
            }
            else
            {
                img_Character[i].gameObject.SetActive(false);
            }
        }
    }

}
