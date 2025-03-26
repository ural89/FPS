using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataContainer : MonoBehaviour, IPlayerDataContainer
{
    [SerializeField] private PlayerData[] playerDatas;

    public PlayerData GetPlayerData() => playerDatas[PlayerPrefs.GetInt("PlayerIndex", 0)];
}
