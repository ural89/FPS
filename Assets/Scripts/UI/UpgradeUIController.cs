using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradeUIController : MonoBehaviour
{
    [Inject] private IPlayerDataContainer playerDataContainer;
    [SerializeField] private float upgradeSpeedAmount = 1;
    [SerializeField] private float upgradeRunSpeedAmount = 1;
    [SerializeField] private float upgradeJumpForceAmount = 1;
    public void OnClickUpgradeSpeed()
    {
        playerDataContainer.GetPlayerData().UpgradeMoveSpeed(upgradeSpeedAmount);
    }
    public void OnClickUpgradeRunSpeed()
    {
        playerDataContainer.GetPlayerData().UpgradeRunSpeed(upgradeRunSpeedAmount);
    }
    public void OnClickUpgradeJumpForce()
    {
        playerDataContainer.GetPlayerData().UpgradeJumpForce(upgradeJumpForceAmount);
    }
}
