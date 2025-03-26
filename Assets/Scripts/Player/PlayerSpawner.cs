using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerSpawner : MonoBehaviour
{
    [Inject] private IPlayerFactory playerFactory;

    private async void Awake()
    {
        Player player = await playerFactory.CreatePlayerAsync(Vector3.zero);

    }
}
