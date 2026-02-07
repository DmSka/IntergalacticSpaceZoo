using System.Collections;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    public GameObject[] rooms;          // Room prefabs
    public Transform spawnLocation;     // Where to spawn the rooms
    private int currentIndex = 0;       // Current room index
    private GameObject currentRoomInstance; // The currently spawned room

    public float displayDelay = 2f;

    // Spawn the current room immediately
    public void DisplayRoom()
    {
        // Destroy the old room if it exists
        if (currentRoomInstance != null)
        {
            Destroy(currentRoomInstance);
        }

        // Spawn the new room at the spawn location
        currentRoomInstance = Instantiate(rooms[currentIndex], spawnLocation.position, Quaternion.identity);
    }

    public void NextRoom()
    {
        currentIndex++;
        if (currentIndex >= rooms.Length) currentIndex = 0;

        StartCoroutine(DisplayRoomDelayed());
    }

    public void PrevRoom()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = rooms.Length - 1;

        StartCoroutine(DisplayRoomDelayed());
    }

    IEnumerator DisplayRoomDelayed()
    {
        yield return new WaitForSeconds(displayDelay);
        DisplayRoom();
    }
}
