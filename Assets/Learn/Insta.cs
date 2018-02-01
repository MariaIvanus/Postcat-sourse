using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insta : MonoBehaviour {

   /* public GameObject wreck;

    // As an example, we turn the game object into a wreck after 3 seconds automatically
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        KillSelf();
    }

    // Calls the fire method when holding down ctrl or mouse
    void KillSelf()
    {
        // Instantiate the wreck game object at the same position we are at
        GameObject wreckClone = (GameObject)Instantiate(wreck, transform.position, transform.rotation);

        // Sometimes we need to carry over some variables from this object to the wreck
        // wreckClone.GetComponent<MyScript>().someVariable = GetComponent<MyScript>().someVariable;

        // Kill ourselves
        Destroy(gameObject);
    }*/


    //---------------------------------------------
    /*public Rigidbody rocket;
    public float speed = 10f;
    void FireRocket()
    {
        //Трансформ от объекта к которому прикриплен скрипт, а префаб у нас в переменной rocket
        //По сути скрипт контроллер создающий ракеты из префабов в своей позиции
        Rigidbody rocketClone = (Rigidbody)Instantiate(rocket, transform.position, transform.rotation);
        rocketClone.velocity = transform.forward * speed;

        // You can also acccess other components / scripts of the clone
        //rocketClone.GetComponent<MyRocketScript>().DoSomething();
    }
    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireRocket();
        }
    }*/
    //---------------------------------------------
    /*public Transform brick;
    void Start () {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Instantiate(brick, new Vector3(x, y, 0), Quaternion.identity);
            }
        }*/
    //---------------------------------------------
    /*for (int y = 0; y < 5; y++)
    {
        for (int x = 0; x < 5; x++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.transform.position = new Vector3(x, y, 4);
        }
    }*/
}
