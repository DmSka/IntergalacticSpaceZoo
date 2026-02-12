using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUIManager : MonoBehaviour
{
    public Animator doorLeft;
    public Animator doorRight;
    public RoomManagement roomManagement;

    public void Awake()
    {
        roomManagement = GameObject.Find("RoomManagement").GetComponent<RoomManagement>();
    }

    public void DoorAnimation()
    {
        doorLeft.SetTrigger("OpenDoor");
        doorRight.SetTrigger("OpenDoor");
    }

    public void NextRoom()
    {
        DoorAnimation();
        roomManagement.NextRoom();
    }

    public void PrevRoom() 
    {
        DoorAnimation();
        roomManagement.PrevRoom();
    }
}
