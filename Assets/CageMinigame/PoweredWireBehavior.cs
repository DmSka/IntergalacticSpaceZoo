using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    public PoweredWireStats poweredWireS;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        poweredWireS = gameObject.GetComponent<PoweredWireStats>();
        line = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        line.SetPosition(0, new Vector3(gameObject.transform.position.x-.1f, gameObject.transform.position.y, gameObject.transform.position.z));
        line.SetPosition(1, new Vector3(gameObject.transform.position.x - .4f, gameObject.transform.position.y, gameObject.transform.position.z));
    }

    public void Reset()
    {
        mouseDown = false;
        gameObject.transform.position = poweredWireS.startPosition;
        poweredWireS.connected = false;
    }

    private void OnMouseDown()
    {
        mouseDown = true;
    }

    private void OnMouseOver()
    {
        poweredWireS.movable = true;
    }

    private void OnMouseExit()
    {
        if (!poweredWireS.movable)
        {
            poweredWireS.movable = false;
        }
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        if(!poweredWireS.connected)
            gameObject.transform.position = poweredWireS.startPosition;
        if(poweredWireS.connected)
            gameObject.transform.position = poweredWireS.connectedPosition;
    }

    void MoveWire()
    {
        if (mouseDown && poweredWireS.movable)
        {
            poweredWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
        }
        else
            poweredWireS.movable = false;
    }
}
