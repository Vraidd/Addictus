using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SerializableVector3
{
    public float x;
    public float y;
    public float z;
    public Vector3 GetPos()
    {
        return new Vector3(x,y,z);
    }
}
[System.Serializable]
public struct Serializablevector2
{
    public float x;
    public float y;
    public Vector2 GetLastMove()
    {
        return new Vector2(x,y);
    }
}

[System.Serializable]
public class PlayerData 
{
    public static float playerHealth;
    public static float playerHapp;
    public static float playerProg;
    public static string lastScene;
    public static SerializableVector3 position;
    public static Serializablevector2 lastMove;
    
    
}
