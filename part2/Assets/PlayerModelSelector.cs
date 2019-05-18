using SWNetwork;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSelector : MonoBehaviour
{
    public List<GameObject> models;
    int currentModelIndex_ = 0;

    SyncPropertyAgent syncPropertyAgent;
    NetworkID networkID;

    const string MODEL_INDEX = "ModelIndex";

    // Start is called before the first frame update
    void Start()
    {
        syncPropertyAgent = GetComponent<SyncPropertyAgent>();
        networkID = GetComponent<NetworkID>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && networkID.IsMine)
        {
            int modelCount = models.Count;

            int modelIndex = syncPropertyAgent.GetPropertyWithName(MODEL_INDEX).GetIntValue();

            if(modelCount == 0 || modelCount == 1)
            {
                return;
            }
            else if (modelIndex < models.Count - 1)
            {
                syncPropertyAgent.Modify(MODEL_INDEX, modelIndex + 1);
            }
            else
            {
                syncPropertyAgent.Modify(MODEL_INDEX, 0);
            }
        }
    }

    public void UpdateModel()
    {
        int modelIndex = syncPropertyAgent.GetPropertyWithName(MODEL_INDEX).GetIntValue();

        for (int index = 0; index < models.Count; index++)
        {
            if(index == modelIndex)
            {
                models[index].SetActive(true);
            }
            else
            {
                models[index].SetActive(false);
            }
        }
    }
}
