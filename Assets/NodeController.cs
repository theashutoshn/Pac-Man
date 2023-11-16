using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public bool _canMoveLeft, _canMoveRight, _canMoveUp, _canMoveDown ;
    public GameObject _nodeLeft, _nodeRight, _nodeUp, _nodeDown ;
    void Start()
    {
        RaycastHit2D[] hitsDown;
        //shooting ray down
        hitsDown = Physics2D.RaycastAll(transform.position, -Vector2.up);

        for (int i = 0; i < hitsDown.Length; i++)
        {
            float distance = Mathf.Abs(hitsDown[i].point.y - transform.position.y);
            
            if(distance < 0.4f)
            {
                _canMoveDown = true;
                _nodeDown = hitsDown[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsUp;
        //shooting ray down
        hitsUp = Physics2D.RaycastAll(transform.position, Vector2.up);

        for (int i = 0; i < hitsUp.Length; i++)
        {
            float distance = Mathf.Abs(hitsUp[i].point.y - transform.position.y);

            if (distance < 0.4f)
            {
                _canMoveUp = true;
                _nodeUp = hitsUp[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsRight;
        //shooting ray down
        hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right);

        for (int i = 0; i < hitsRight.Length; i++)
        {
            float distance = Mathf.Abs(hitsRight[i].point.x - transform.position.x);

            if (distance < 0.4f)
            {
                _canMoveRight = true;
                _nodeRight = hitsRight[i].collider.gameObject;
            }
        }

        RaycastHit2D[] hitsLeft;
        //shooting ray down
        hitsLeft = Physics2D.RaycastAll(transform.position, -Vector2.right);

        for (int i = 0; i < hitsLeft.Length; i++)
        {
            float distance = Mathf.Abs(hitsLeft[i].point.x - transform.position.x);

            if (distance < 0.4f)
            {
                _canMoveLeft = true;
                _nodeLeft = hitsLeft[i].collider.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNodeFromDirection(string direction)
    {
        if(direction == "left" && _canMoveLeft)
        {
            return _nodeLeft;
        }
        else if(direction == "right" && _canMoveRight)
        {
            return _nodeRight;
        }
        else if (direction == "up" && _canMoveUp)
        {
            return _nodeUp;
        }
        else if (direction == "down" && _canMoveDown)
        {
            return _nodeDown;
        }
        else
        {
            return null;
        }
    }
}
