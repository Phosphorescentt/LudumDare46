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
    private GameObject[] rooms;
    private GameObject[] deadEnds;
    private GameObject newRoom;
    private GameObject newClosedRoom;
    private bool spawned = false;

    void Start() {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        grid = templates.grid;
        if (openingDirection != 0 && templates.size <= templates.maxSize) {
            Invoke("Spawn", 0.1f);
        }
        
        if (templates.size > templates.maxSize) {
            Invoke("SpawnDeadEnds", 0.1f);
        }
    }

    void Spawn() {
        if (spawned == false) {
            if (openingDirection == 1) {
                // BOTTOM DOOR
                rand = Random.Range(0, templates.bottomRooms.Length);
                rooms = templates.bottomRooms;
            } else if (openingDirection == 2) {
                // TOP DOOR
                rand = Random.Range(0, templates.topRooms.Length);
                rooms = templates.topRooms;
            } else if (openingDirection == 3) {
                // LEFT DOOR
                rand = Random.Range(0, templates.leftRooms.Length);
                rooms = templates.leftRooms;
            } else if (openingDirection == 4) {
                // RIGHT DOOR
                rand = Random.Range(0, templates.rightRooms.Length);
                rooms = templates.rightRooms;
            }

            newRoom = rooms[rand];
            newRoom = Instantiate(newRoom, transform.position, newRoom.transform.rotation);
            newRoom.transform.SetParent(grid.transform);
            
            spawned = true;
            templates.size++;
        }
    }

    void SpawnDeadEnds() {
        deadEnds = templates.deadEnds;
        if (spawned == false) {
            newRoom = deadEnds[openingDirection-1];
            newRoom = Instantiate(newRoom, transform.position, newRoom.transform.rotation);
            newRoom.transform.SetParent(grid.transform);
            spawned = true;
            templates.size++;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        grid = templates.grid;
        
        if (other.CompareTag("Spawn Point")) {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                newClosedRoom = Instantiate(templates.closedRoom, transform.position, templates.closedRoom.transform.rotation);
                newClosedRoom.transform.SetParent(grid.transform);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
