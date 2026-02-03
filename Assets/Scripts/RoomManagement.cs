using System.Collections;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    public GameObject[] rooms;
    private int currentIndex = 0;
    public GameObject currentRoom;
    public GameObject roomTemplate;

    public float displayDelay = 2f;

    public void DisplayRoom()
    {
        roomTemplate
            .GetComponent<SpriteRenderer>()
            .sprite = currentRoom.GetComponent<SpriteRenderer>().sprite;
    }

    public void NextRoom()
    {
        currentIndex++;
        if (currentIndex >= rooms.Length) currentIndex = 0;

        currentRoom = rooms[currentIndex];
        StartCoroutine(DisplayRoomDelayed());
    }

    public void PrevRoom()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = rooms.Length - 1;

        currentRoom = rooms[currentIndex];
        StartCoroutine(DisplayRoomDelayed());
    }

    IEnumerator DisplayRoomDelayed()
    {
        yield return new WaitForSeconds(displayDelay);
        DisplayRoom();
    }
}
