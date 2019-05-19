using System.Collections;
using SWNetwork;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    public float teleportDistance;

    NetworkID networkID;
    RemoteEventAgent remoteEventAgent;

    const string TELEPORT = "Teleport";
    // Start is called before the first frame update
    void Start()
    {
        networkID = GetComponent<NetworkID>();
        remoteEventAgent = GetComponent<RemoteEventAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && networkID.IsMine)
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * teleportDistance);

            SWNetworkMessage message = new SWNetworkMessage();
            message.Push(targetPosition);

            remoteEventAgent.Invoke(TELEPORT, message);
        }
    }

    public void Teleport(SWNetworkMessage message)
    {
        Vector3 targetPosition = message.PopVector3();
        transform.position = targetPosition;
    }
}
