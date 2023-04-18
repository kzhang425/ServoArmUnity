using Lib;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class ArduinoGameObject : MonoBehaviour
{
    public Interface inter;
    // Start is called before the first frame update
    void Start()
    {
        inter = new Interface();
        Debug.Log("Initialized Arduino Interface");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Takes the string argument and transforms it into the enums that the functions use
    private Interface.Movement assign(string cmd)
    {
        Interface.Movement move_type;
        switch (cmd)
        {
            case "pan":
                move_type = Interface.Movement.Pan;
                break;

            case "tilt":
                move_type = Interface.Movement.Tilt;
                break;

            case "step":
                move_type = Interface.Movement.Step;
                break;

            default:
                move_type = Interface.Movement.Error;
                break;
        }
        return move_type;
    }

    public void write_movement(string cmd, int pos)
    {
        Interface.Movement move_type = assign(cmd);

        if (move_type == Interface.Movement.Error) return;

        inter.write_movement(pos, move_type);
    }

    public void write_speed_movement(string cmd, int pos, int speed)
    {
        Interface.Movement move_type = assign(cmd);

        if (move_type == Interface.Movement.Error) return;

        inter.write_controlled_speed(pos, move_type, speed);
    }
}
