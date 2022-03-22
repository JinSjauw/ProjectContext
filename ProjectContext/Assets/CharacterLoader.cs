using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class CharacterLoader : MonoBehaviour
{
    public TextMeshProUGUI[] statList;
    public RawImage characterPortrait;

    string filePath;

    public Character character = new Character();

    Texture2D strBody, conBody, baseBody;

    private void Start()
    {
        baseBody = Resources.Load("Images/base") as Texture2D;
        conBody = Resources.Load("Images/conBodyFull") as Texture2D;
        strBody = Resources.Load("Images/strBodyFull") as Texture2D;

        Debug.Log("Images: " + baseBody + conBody + strBody);
    }

    // Read the JSON file
    void LoadCharacter()
    {
        StreamReader reader = new StreamReader(filePath);

        character = JsonUtility.FromJson<Character>(reader.ReadToEnd());
        CharacterManager.characterList.Add(character);

        if (character != null) 
        {
            int[] stats = new int[] { character.i_ConstitutionPoints, character.i_StrengthPoints , character.i_DexterityPoints, character.i_IntelligencePoints, };
            int largestNumber = 0;
            int mainStat = 0;
            for (int i = 0; i < stats.Length; i++) 
            {
                if (stats[i] > largestNumber) 
                {
                    largestNumber = stats[i];
                    mainStat = i;
                }
            }

            switch (mainStat) 
            {
                case 0:
                    character.characterImage = conBody;
                    break;
                case 1:
                    character.characterImage = strBody;
                    break;
                case 2:
                    character.characterImage = baseBody;
                    break;
                case 3:
                    character.characterImage = baseBody;
                    break;
            }

            Debug.Log("Character Image Loaded! " + character.characterImage);


            statList[0].text = character.i_ConstitutionPoints.ToString();
            statList[1].text = character.i_StrengthPoints.ToString();
            statList[2].text = character.i_DexterityPoints.ToString();
            statList[3].text = character.i_IntelligencePoints.ToString();
            statList[4].text = character.i_TotalPoints.ToString();

            characterPortrait.texture = character.characterImage;

            Debug.Log("Character Loaded! " + CharacterManager.characterList.Count);
        }
    }

    public void GetPath() 
    {
        filePath = EditorUtility.OpenFilePanel("Get Character File", "", "");

        if(filePath != null) 
        {
            LoadCharacter();
        }
    }
    
}
