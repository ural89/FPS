using UnityEngine;
using Zenject;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerFactory : IPlayerFactory
{
    private readonly DiContainer container;
    [SerializeField] private AssetReference[] playerAssetReferences;
    public PlayerFactory(AssetReference[] playerAssetReferences, DiContainer container)
    {
        this.playerAssetReferences = playerAssetReferences;
        this.container = container;
    }

    public async Task<Player> CreatePlayerAsync(Vector3 spawnPosition)
    {

        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(playerAssetReferences[PlayerPrefs.GetInt("PlayerIndex", 0)]);
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject playerObj = GameObject.Instantiate(handle.Result, spawnPosition, Quaternion.identity);
            Addressables.Release(handle);

            InjectDependencies(playerObj);

            return playerObj.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Failed to load Addressable Player Prefab!");
            return null;
        }
    }

    private void InjectDependencies(GameObject playerObj)
    {
        var interactor = playerObj.GetComponent<PlayerInteractor>();
        if (interactor != null)
        {
            var tutorialHandler = container.Resolve<IInteractionTextHandler>();
            interactor.Construct(tutorialHandler);
        }

        var characterMovementHandler = playerObj.GetComponent<CharactermovementHandler>();
        if (characterMovementHandler != null)
        {
            var playerDataContainer = container.Resolve<IPlayerDataContainer>();
            characterMovementHandler.Construct(playerDataContainer);
        }
    }
}
