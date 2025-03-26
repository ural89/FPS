using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private AssetReference[] playerAssetReferences;
    public override void InstallBindings()
    {
        Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle().WithArguments(playerAssetReferences);
        Container.Bind<IInteractionTextHandler>().FromComponentInHierarchy().AsSingle();
        Container.Bind<IPlayerDataContainer>().FromComponentInHierarchy().AsSingle();

        
    }
}