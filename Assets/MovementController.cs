using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    //the next node towards which our player moves
    public GameObject currentNode;

    public float speed = 4f;

    public string direction = "";
    public string lastMovingDirection = "";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);

        //figure out if we are at the center of the current node
        if(transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y)
        {
            // get the next node from node controller using our current direction
            GameObject newNode = currentNodeController.GetNodeFromDirection(direction);
            
            // if we can move in the desired direction
            if(newNode != null)
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }

            // we can't move in desired direction, try to keep going in the last moving direction
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodeFromDirection(direction);
                if(newNode != null)
                {
                    currentNode = newNode;
                }
            }
        }
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;
    }
}
