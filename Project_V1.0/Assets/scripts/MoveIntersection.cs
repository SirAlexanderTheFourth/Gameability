using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//class to manage the precedence of the intersection
public class MoveIntersection : MonoBehaviour
{
    //attributes whith the cars to move
    [SerializeField] WaypointMover carRed;
    [SerializeField] WaypointMover carYellow;
    [SerializeField] WaypointMover carWite;
    [SerializeField] WaypointMover carSlash;

    [SerializeField] int[] arrayOrder;

    // create a new Hand object
    public Hand_Left hand_Left = new Hand_Left();
    public Hand_Right hand_Right = new Hand_Right();

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Precedence();
    }

    private void carTransition(WaypointMover car)
    {
        //conditions to verify which car has to move
        if (car.indexCar == hand_Right.getFinger() || car.indexCar == hand_Left.getFinger())
        {
            car.MoveCar();
        }

        if (arrayOrder[0]==5){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        if (car.complete && car.finish)
        {
            if (car.indexCar == arrayOrder[0])
            {
                Debug.Log("GIUSTO");
                car.finish = false;
                List<int> list = new List<int>(arrayOrder);
                list.RemoveAt(0);
                arrayOrder = list.ToArray();
                Debug.Log(arrayOrder[0]);

            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    //function that moves the cars according to the precedences
    private void Precedence()
    {
        carTransition(carRed);
        carTransition(carYellow);
        carTransition(carWite);
        carTransition(carSlash);
    }
}