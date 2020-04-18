using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // 1 => need door on bottom
    // 2 => need door on top
    // 3 => need door on left
    // 4 => need door on right
    public int openingDirection;

    private RoomTemplates templates;
    private GameObject grid;
    
    private int rand;
    private GameObject room;
    private GameObject newRoom;
    private bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (openingDirection != 0 && templates.size <= templates.maxSize) {
            grid = templates.grid;

            Invoke("Spawn", 0.5f);
        }
    }

    void Spawn() {
        if (spawned == false) {
            if (openingDirection == 1) {
                // BOTTOM DOOR
                rand = Random.Range(0, templates.bottomRooms.Length);
                room = templates.bottomRooms[rand];
                newRoom = Instantiate(room, transform.position, room.transform.rotation);
                newRoom.transform.SetParent(grid.transform);
            } else if (openingDirection == 2) {
                // TOP DOOR
                rand = Random.Range(0, templates.topRooms.Length);
                room = templates.topRooms[rand];
                newRoom = Instantiate(room, transform.position, room.transform.rotation);
                newRoom.transform.SetParent(grid.transform);
            } else if (openingDirection == 3) {
                // LEFT DOOR
                rand = Random.Range(0, templates.leftRooms.Length);
                room = templates.leftRooms[rand];
                newRoom = Instantiate(room, transform.position, room.transform.rotation);
                newRoom.transform.SetParent(grid.transform);
            } else if (openingDirection == 4) {
                // RIGHT DOOR
                rand = Random.Range(0, templates.rightRooms.Length);
                room = templates.rightRooms[rand];
                newRoom = Instantiate(room, transform.position, room.transform.rotation);
                newRoom.transform.SetParent(grid.transform);
            }
            spawned = true;
            templates.size++;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Spawn Point") && other.GetComponent<RoomSpawner>().spawned == true) {
            Destroy(gameObject);
        }
    }
}
