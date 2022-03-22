using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scenes 
    {
        CharacterScene,
        BattleScene,
    }
    public static void Load(Scenes scene) 
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
