using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player_Nav))]

public class MouseClick_Move : MonoBehaviour
{   


    //Declaration
    public GameObject model;
    public LayerMask Walkable_Mask;
    public bool Move_State = false;
    private Vector3 target = new Vector3();
    // public float move_speed = 0.5f; 

    public Animator animator;

    public float distance = 0.01f;

    // private float camera_distance = 10f;
    // private float camera_height = 10f;
    // private float camera_speed = 4f;

    private Transform follow;
    private Vector3 Target_Position;

    Player_Nav Nav;


    // Start is called before the first frame update
    void Start()
    {

        Nav = GetComponent<Player_Nav>();
        animator.GetComponent<Animator>().SetBool("param_toidle", true);
        // follow = GameObject.FindWithTag("Player").transform;

    }


    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, Walkable_Mask)) //Means that the ray hit something, and names something as hit...
        {
            
            if(Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "ground") //When our ray hit the "ground", player move...
            {

                Move_State = true;
                target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                animator.GetComponent<Animator>().SetBool("param_idletowalk", true);
            }
        }

        // float Real_Speed = move_speed * Time.deltaTime;
        // Vector3 Target_Direction = target - model.transform.position;
        // Vector3 New_Direction = Vector3.RotateTowards(model.transform.forward, Target_Direction, Real_Speed*10, 0.0F);
        // model.transform.rotation = Quaternion.LookRotation(New_Direction);

        


        if(Move_State)
        {
            animator.GetComponent<Animator>().SetBool("param_idletowalk", true);
            if(Vector3.Distance(model.transform.position, target) < 0.1f)
            {
                Move_State = false;
                animator.GetComponent<Animator>().SetBool("param_idletowalk", false);
            }

            else
            {
                // model.transform.position = Vector3.MoveTowards(model.transform.position, target, Real_Speed);

                // Target_Position = follow.position + Vector3.up * camera_height - follow.forward * camera_distance;
                // transform.position = Vector3.Lerp(transform.position, Target_Position, camera_speed * Time.deltaTime);

                // transform.LookAt(follow);

                Nav.MoveToTarget(target); //AI moving


            }

        }

        else
        {
            animator.GetComponent<Animator>().SetBool("param_idletowalk", false);
        }

    }
}
