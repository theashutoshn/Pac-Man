using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementController _moveController;
    void Start()
    {
        _moveController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _moveController.SetDirection("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _moveController.SetDirection("right");
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _moveController.SetDirection("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _moveController.SetDirection("down");
        }
    }
}
