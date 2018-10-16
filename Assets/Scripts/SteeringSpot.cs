using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSpot : MonoBehaviour
{
    public GameObject PlayerOccupation;
    private PlayerController _PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("3") && PlayerOccupation != null)
        {
            Debug.Log("Exit steering");
            _PlayerController.IsStearing = false;
            _PlayerController = null;
            PlayerOccupation = null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player" && PlayerOccupation == null)
        {
            Debug.Log("Enter steering");
            PlayerOccupation = other.gameObject;
            _PlayerController = other.gameObject.GetComponent<PlayerController>();
            _PlayerController.IsStearing = true;
        }
    }
}
