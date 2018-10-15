using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{
    public GameObject PlayerPrefab;
    public Transform Spawn;

    private GameObject MyPlayer;
    private PlayerController _PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer == false)
        {
            return;
        }
        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer == false)
        {
            return;
        }
        CmdMovement();
        CmdBodyRotation();
    }

    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject player = Instantiate(PlayerPrefab, GameObject.FindGameObjectWithTag("Spawn").transform.position
            , GameObject.FindGameObjectWithTag("Spawn").transform.rotation);
        player.transform.SetParent(GameObject.FindGameObjectWithTag("Ship").transform);
        MyPlayer = player;
        _PlayerController = MyPlayer.GetComponent<PlayerController>();
        NetworkServer.Spawn(player);
    }

    void CmdMovement()
    {
        _PlayerController.Movement();
    }

    [Command]
    void CmdBodyRotation()
    {
        _PlayerController.BodyRotation();
    }
}
