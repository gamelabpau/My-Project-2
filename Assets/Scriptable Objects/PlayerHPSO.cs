using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerHealthScriptableObject", order = 1)]
public class PlayerHPSO : ScriptableObject
{
    [SerializeField]
    private float playerHP = 100f;

    public float PlayerHp
    {
        get => playerHP;
        set => playerHP = value;
    }
}
