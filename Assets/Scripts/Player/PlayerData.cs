using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float runSpeed = 8;
    [SerializeField] private float jumpForce = 6;
    public void UpgradeMoveSpeed(float upgradeAmount) => moveSpeed += upgradeAmount;
    public void UpgradeRunSpeed(float upgradeAmount) => runSpeed += upgradeAmount;
    public void UpgradeJumpForce(float upgradeAmount) => jumpForce += upgradeAmount;
    public float GetMoveSpeed() => moveSpeed;
    public float GetRunSpeed() => runSpeed;
    public float GetJumpForce() => jumpForce;

}