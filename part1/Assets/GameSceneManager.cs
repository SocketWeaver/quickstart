using SWNetwork;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void OnSpawnerReady(bool alreadyFinishedSceneSetup)
    {
        if (!alreadyFinishedSceneSetup)
        {
            float positionX = Random.Range(-6.0f, 6.0f);
            float positionY = Random.Range(-6.0f, 6.0f);

            NetworkClient.Instance.LastSpawner.SpawnForPlayer(0, new Vector3(positionX, positionY, 0), Quaternion.identity);

            NetworkClient.Instance.LastSpawner.PlayerFinishedSceneSetup();
        }
    }
}
