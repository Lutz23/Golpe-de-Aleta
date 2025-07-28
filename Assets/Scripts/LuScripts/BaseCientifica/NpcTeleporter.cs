using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeleporter : MonoBehaviour
{
    public Transform npc; 
    public Vector3 teleportPosition; 
    public float teleportDelay = 2f; 

    private bool hasTeleported = false;

    void Start()
    {
        if (npc == null)
        {
            Debug.LogError("NPC not assigned!");
            return;
        }

        // Empieza Teleport despues de un delay (o llama TeleportNow() directly)
        Invoke(nameof(TeleportNow), teleportDelay);
    }

    void TeleportNow()
    {
        if (hasTeleported) return;

        npc.position = teleportPosition;
        hasTeleported = true;

        Debug.Log($"NPC teleported to {teleportPosition}");
    }
}
