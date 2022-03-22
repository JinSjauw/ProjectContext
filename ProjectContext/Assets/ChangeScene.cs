using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().interactable = false;
    }

    private void FixedUpdate()
    {
        if(CharacterManager.characterList.Count >= 2)
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnClick() 
    {
        Loader.Load(Loader.Scenes.BattleScene); 
    }
}
