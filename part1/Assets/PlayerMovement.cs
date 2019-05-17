using SWNetwork;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    NetworkID networkID;
    // Start is called before the first frame update
    void Start()
    {
        networkID = GetComponent<NetworkID>();
    }

    // Update is called once per frame
    void Update()
    {
        if (networkID.IsMine)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            float newX = transform.position.x + speed * horizontal * Time.deltaTime;
            float newY = transform.position.y + speed * vertical * Time.deltaTime;

            transform.position = new Vector3(newX, newY, 0);
        }
    }
}
