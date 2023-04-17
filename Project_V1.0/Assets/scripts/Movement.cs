using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// see the direction of the hand
public class Movement : MonoBehaviour
{
    public GameObject hand_sx, hand_dx; // right and left hand's middle points
    private double x_hand, y_hand, z_hand; // x, y, z hand coordinates
    private int direction_x, direction_y; // direction of the hand
    private double point_left_hand_x, point_right_hand_x; // starting point x of the hands
    private double point_left_hand_y, point_right_hand_y; // starting point y of the hands

    // Start is called before the first frame update
    void Start()
    {

        // Set the reference points for the x, y coordinates of each hand.
        point_left_hand_x = hand_sx.transform.position.x;
        point_right_hand_x = hand_dx.transform.position.x;
        point_left_hand_y = hand_sx.transform.position.y;
        point_right_hand_y = hand_dx.transform.position.y;
    }

    // MAIN CICLE
    void Update()
    {

        // check if the right hand is on the screen
        if (hand_dx.activeSelf == true)
        {

            // get the x,y,z coordinates of the right hand's middle point
            x_hand = hand_dx.transform.position.x;
            y_hand = hand_dx.transform.position.y;
            z_hand = hand_dx.transform.position.z;

            direction_x = OrizzontalDirection(x_hand, point_right_hand_x);
            direction_y = VerticalDirection(y_hand, point_right_hand_y);

            printDirection(direction_x);
            printDirection(direction_y);

            //Debug.Log("Right: [X = " + x_hand + " Y = " + y_hand + " Z = "+ z_hand+"]");
            //Debug.Log("number RIGHT: " + direction );

        }

        // check if the left hand is on the screen
        if (hand_sx.activeSelf == true)
        {

            // get the x,y,z coordinates of the left hand's middle point
            x_hand = hand_sx.transform.position.x;
            y_hand = hand_sx.transform.position.y;
            z_hand = hand_sx.transform.position.z;

            direction_x = OrizzontalDirection(x_hand, point_left_hand_x);
            direction_y = VerticalDirection(y_hand, point_left_hand_y);

            printDirection(direction_x);
            printDirection(direction_y);

            //Debug.Log("Left: [X = " + x_hand + " Y = " + y_hand + " Z = "+ z_hand+"]");
            //Debug.Log("number LEFT: " + direction );
        }

        getDirectionX();
    }

    // see in which part of the screen is the hand and return a number if the hand is on the left or on the right of the starting x point.
    int OrizzontalDirection(double x_hand, double point_hand_x)
    {

        // if the x of the hand is equal of its initial postion, it return 0
        if (x_hand == point_hand_x)
        {
            return 0;

        }
        else
        {

            if (x_hand > point_hand_x)
            {
                return 1;

            }
            else if (x_hand < point_hand_x)
            {
                return 2;

            }
            else
            {
                return 0;

            }
        }
    }

    // see in which part of the screen is the hand and return a number if the hand is up or down of the starting y point.
    int VerticalDirection(double y_hand, double point_hand_y)
    {

        // if the y of the hand is equal of its initial postion, it return 0
        if (y_hand == point_hand_y)
        {
            return 0;

        }
        else
        {
            if (y_hand > point_hand_y)
            {
                return 3;

            }
            else if (y_hand < point_hand_y)
            {
                return 4;

            }
            else
            {
                return 0;

            }
        }
    }


    // print the position of the hand based on the number that it recives
    void printDirection(int direction)
    {

        switch (direction)
        {

            // 0 = No direction
            case 0:
                Debug.Log("No direction");
                break;

            // 1 = Right
            case 1:
                Debug.Log("Right");
                break;

            // 2  = Left
            case 2:
                Debug.Log("Left");
                break;

            // 3 = Up
            case 3:
                Debug.Log("Up");
                break;

            // 4 = Down
            case 4:
                Debug.Log("Down");
                break;
        }
    }

    public int getDirectionX(){
        return direction_x;
    }
}