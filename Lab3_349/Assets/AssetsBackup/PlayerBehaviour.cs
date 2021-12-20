using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    //Never set the value of a public variable here - the inspector will override it without telling you.
    //If you need to, set it in Start() instead

    public float speed; //'float' is short for floating point number, which is basically just a normal number

    public List<WeaponBehaviour> weapons = new List<WeaponBehaviour>();
    public int selectedWeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        References.thePlayer = gameObject;
        selectedWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //WASD to move
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = inputVector * speed;

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        //Face the new position
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition);

        //Firing
        // if (weapons.Count > 0 && Input.GetButton("Fire1"))
        // {
        //     //Tell our weapon to fire
        //     weapons[selectedWeaponIndex].Fire(cursorPosition);
        // }

        //weapon switching
        // if (Input.GetButtonDown("Fire2"))
        // {
        //     ChangeWeaponIndex(selectedWeaponIndex + 1);
        // }
    }

    // private void ChangeWeaponIndex(int index)
    // {

    //     //Change our index
    //     selectedWeaponIndex = index;
    //     //If it's gone too far, loop back around
    //     if (selectedWeaponIndex >= weapons.Count)
    //     {
    //         selectedWeaponIndex = 0;
    //     }

    //     //For each weapon in our list
    //     for (
    //         int i = 0; //Declare a variable to keep track of how many iterations we've done
    //         i < weapons.Count; //Set a limit for how high this variable can go
    //         i++ //Run this after each time we iterate - increase the iteration count
    //     )
    //     {
    //         if (i == selectedWeaponIndex)
    //         {
    //             //If it's the one we just selected, make it visible - 'enable' it
    //             weapons[i].gameObject.SetActive(true);
    //         } else
    //         {
    //             //If it's not the one we just selected, hide it - disable it.
    //             weapons[i].gameObject.SetActive(false);
    //         }
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        WeaponBehaviour theirWeapon = other.GetComponentInParent<WeaponBehaviour>();
        if (theirWeapon != null)
        {
            //Add it to our internal list
            weapons.Add(theirWeapon);
            //Move it to our location
            theirWeapon.transform.position = transform.position;
            theirWeapon.transform.rotation = transform.rotation;
            //Parent it to us - attach it to us, so it moves with us
            theirWeapon.transform.SetParent(transform);
            //Select it!
            //ChangeWeaponIndex(weapons.Count - 1);
        }
    }

}
