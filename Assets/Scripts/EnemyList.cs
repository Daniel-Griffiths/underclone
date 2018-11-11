using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string name = "Dummy";
    public int hp = 10;
    public int gold = 0;
    public Sprite sprite;
    public string music;
    public string[] dialog = {
        "test dialog 1",
        "test dialog 2"
    };
}

[System.Serializable]
public class EnemyList : MonoBehaviour
{
    public Enemy[] enemies;
}
