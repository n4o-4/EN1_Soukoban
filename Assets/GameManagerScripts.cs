using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int[] map;

    void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i<map.Length; i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex()
    {
        for(int i = 0;i<map.Length;i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        if (moveTo<0||moveTo>=map.Length)
        {
            return false;
        }
        if (map[moveTo] == 2)
        {
            int Velocity = moveTo - moveFrom;
            map[moveTo + Velocity] = 2;
            bool success = MoveNumber(2, moveTo, moveTo+Velocity);
            if (!success) { return false; }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello World");//çÌèú

        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            int PlayerIndex = -1;
            PlayerIndex = GetPlayerIndex();
            if (MoveNumber(1, PlayerIndex, PlayerIndex+ 1))
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int PlayerIndex = -1;
            PlayerIndex = GetPlayerIndex();
            if (MoveNumber(1, PlayerIndex, PlayerIndex - 1))
            PrintArray();
        }
    }
}
