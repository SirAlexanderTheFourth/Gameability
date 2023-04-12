using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Count the extended fingers
public class Hand : MonoBehaviour
{
    private const int POWER = 2; // exponent to calculate the distance of the fingers
    private const double BORDER_DISTANCE_RL = 0.08; // right and left border width (this number was chose empirically after some tests)
    private const double BORDER_DISTANCE_UD = 0.03; // up and down border height (this number was chose empirically after some tests)
    private const double MINIMAL_DISTANCE = 0.092; // minimal distance from the central point to indentify if a finger is extended (this number was chose empirically after some tests)
    private const double MINIMAL_DISTANCE_THUMB = 0.0958; // minimal distance for the thumbs because they have a different distance from the central point (this number was chose empirically after some tests)

    public GameObject hand; // right and left hand's middle points
    public GameObject thumb; // right and left thumbs
    public GameObject index; // right and left indexes
    public GameObject middle; // right and left middles
    public GameObject ring; // right and left rings
    public GameObject pinky; // right and left pinkyies

    private double index_distance, middle_distance, thumb_distance, pinky_distance, ring_distance; // distance of every finger
    private double x_hand, y_hand, z_hand; // x, y, z hand coordinates
    private double x_index, x_middle, x_thumb, x_pinky, x_ring; // x coordinates of every finger
    private double y_index, y_middle, y_thumb, y_pinky, y_ring; // y coordinates of every finger
    private double z_index, z_middle, z_thumb, z_pinky, z_ring; // z coordinates of every finger
    private double middle_distance_right, middle_distance_left, middle_distance_up, middle_distance_down; // We don't use this variables because we have decided that it's more easy to play the game without those
    private int[] fingerUp = { 0, 0, 0, 0, 0 }; // array for see if a finger is exstended or not
    private int counter;// contains the number to return

    // inizialize and reset all the variables
    void Start()
    {
        reset();
    }

    // MAIN CICLE
    void Update()
    {

        // check if the right hand is on the screen
        if (hand.activeSelf == true)
        {

            // get the x,y,z coordinates of the hand's
            assignCoordinates();

            getFinger();
            getDirection();
            assign_distance();
            HandDirection();

            //Debug.Log("Fingers: " + getFinger());
        }

        // DB: getFinger();
    }


    void assignCoordinates()
    {
        // get the x,y,z coordinates of the hand's middle point
        x_hand = hand.transform.position.x;
        y_hand = hand.transform.position.y;
        z_hand = hand.transform.position.z;

        // get the x,y,z coordinates of the hand's thumb
        x_thumb = thumb.transform.position.x;
        y_thumb = thumb.transform.position.y;
        z_thumb = thumb.transform.position.z;

        // get the x,y,z coordinates of the hand's index
        x_index = index.transform.position.x;
        y_index = index.transform.position.y;
        z_index = index.transform.position.z;

        // get the x,y,z coordinates of the hand's middle
        x_middle = middle.transform.position.x;
        y_middle = middle.transform.position.y;
        z_middle = middle.transform.position.z;

        // get the x,y,z coordinates of the hand's ring
        x_ring = ring.transform.position.x;
        y_ring = ring.transform.position.y;
        z_ring = ring.transform.position.z;

        // get the x,y,z coordinates of the hand's pinky
        x_pinky = pinky.transform.position.x;
        y_pinky = pinky.transform.position.y;
        z_pinky = pinky.transform.position.z;
    }

    // calculate distance of every finger from the middle point of the hand
    double calculate_distance(double x, double y, double z, double x_finger, double y_finger, double z_finger)
    {
        // Pythagorean theorem
        return Math.Sqrt((Math.Pow(x - x_finger, POWER) + Math.Pow(y - y_finger, POWER) + Math.Pow(z - z_finger, POWER))); // return double
    }

    // recognizes the number made with the hand and return the number of the fingers extended
    int extended_fingers_counter()
    {

        counter = 0; // reset the counter

        // check if there are 0 or 5 fingers extended on the hand and assign 0 to counter
        if (thumb_distance >= MINIMAL_DISTANCE_THUMB && index_distance >= MINIMAL_DISTANCE && middle_distance >= MINIMAL_DISTANCE && ring_distance >= MINIMAL_DISTANCE && pinky_distance >= MINIMAL_DISTANCE)
        {
            counter = 0;
        }
        else if (thumb_distance < MINIMAL_DISTANCE_THUMB && index_distance < MINIMAL_DISTANCE && middle_distance < MINIMAL_DISTANCE && ring_distance < MINIMAL_DISTANCE && pinky_distance < MINIMAL_DISTANCE)
        {
            counter = 0;
        }

        // if the finger is extended set to one the cell of the correspondent finger
        else
        {
            if (thumb_distance >= MINIMAL_DISTANCE_THUMB)
            {
                fingerUp[0] = 1;
            }
            else
            {
                fingerUp[0] = 0;
            }
            if (index_distance >= MINIMAL_DISTANCE)
            {
                fingerUp[1] = 1;
            }
            else
            {
                fingerUp[1] = 0;
            }
            if (middle_distance >= MINIMAL_DISTANCE)
            {
                fingerUp[2] = 1;
            }
            else
            {
                fingerUp[2] = 0;
            }
            if (ring_distance >= MINIMAL_DISTANCE)
            {
                fingerUp[3] = 1;
            }
            else
            {
                fingerUp[3] = 0;
            }
            if (pinky_distance >= MINIMAL_DISTANCE)
            {
                fingerUp[4] = 1;
            }
            else
            {
                fingerUp[4] = 0;
            }

            // sum the number of extended fingers
            for (int a = 0; a < 5; a++)
            {
                counter += fingerUp[a];
            }
        }
        return counter; // return int
    }

    // WE DON'T USE THIS FUNCTION
    // see in which part of the screen is the hand and return a number if the hand is on the left or on the right of the starting x point.
    int HandDirection()
    {

        // if the x of the hand is equal of its initial postion, it return 0
        if (x_hand < middle_distance_right && x_hand > middle_distance_left && y_hand < middle_distance_up && y_hand > middle_distance_down)
        {
            return 0;

        }
        else
        {

            if (x_hand < middle_distance_left)
            {
                // Left = 1
                return 1;

            }
            else if (x_hand > middle_distance_right)
            {
                // Right = 2
                return 2;

            }
            else if (y_hand > middle_distance_up)
            {
                // Up = 3
                return 3;
            }
            else if (y_hand < middle_distance_down)
            {
                // Down = 4
                return 4;
            }
            else
            {
                return 0;

            }
        }
    }

    // reset all the distances, array and variables
    void reset()
    {
        thumb_distance = 0;
        index_distance = 0;
        middle_distance = 0;
        ring_distance = 0;
        pinky_distance = 0;

        for (int a = 0; a < 5; a++)
        {
            fingerUp[a] = 0;
        }

        counter = 0;

        // calculate the border of the hands
        middle_distance_up = hand.transform.position.y + BORDER_DISTANCE_UD;
        middle_distance_down = hand.transform.position.y - BORDER_DISTANCE_UD;
        middle_distance_left = hand.transform.position.x - BORDER_DISTANCE_RL;
        middle_distance_right = hand.transform.position.x + BORDER_DISTANCE_RL;
    }

    // assign the distance of every finger
    void assign_distance()
    {
        thumb_distance = calculate_distance(x_hand, y_hand, z_hand, x_thumb, y_thumb, z_thumb);
        index_distance = calculate_distance(x_hand, y_hand, z_hand, x_index, y_index, z_index);
        middle_distance = calculate_distance(x_hand, y_hand, z_hand, x_middle, y_middle, z_middle);
        ring_distance = calculate_distance(x_hand, y_hand, z_hand, x_ring, y_ring, z_ring);
        pinky_distance = calculate_distance(x_hand, y_hand, z_hand, x_pinky, y_pinky, z_pinky);
    }

    // return number of extended fingers
    public int getFinger()
    {
        //Debug.Log("finger counter ----> " + extended_fingers_counter());
        return extended_fingers_counter();
    }

    // WE DON'T USE THIS FUNCTION
    public int getDirection()
    {

        return HandDirection();
    }
}