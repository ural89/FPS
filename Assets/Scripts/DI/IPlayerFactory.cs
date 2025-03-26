
using UnityEngine;
using System.Threading.Tasks;

public interface IPlayerFactory
{
    public Task<Player> CreatePlayerAsync(Vector3 spawnPosition);
}

