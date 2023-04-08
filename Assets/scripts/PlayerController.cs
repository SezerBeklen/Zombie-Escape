using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    
    public int desiredLine = 1;//0:left 1:middle 2:rigt
    public float laneDistance = 4;//the distance betwween to lanes

    [SerializeField] private float jumpForce;
    public float Gravity = -20;
    public menu _menu;
    public BoxCollider karakter; 
     
    public Animator anim;
    private void Start()
    {

       
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        PlayerPrefs.SetFloat("hýz", forwardSpeed);
        if (Time.timeScale != 0)
        {
          
            direction.z = forwardSpeed*Time.deltaTime*5;

          /*  if (_menu.isStart)
            {
                forwardSpeed = 100;

            }*/


            if (controller.isGrounded)
            {

                //direction.y = -1;
                if (Swipemanager.swipeUp )
                {
                    Jump();
                }
                

            }
            else
            {
                direction.y += Gravity * Time.deltaTime;
            }



            if (Swipemanager.swipeDown && controller.isGrounded)
            {
                anim.SetBool("slide", true);
                //forwardSpeed = 600;
                controller.height = 0.50f;
                controller.center = new Vector3(0, 0.2f, 0.06f);
                karakter.center = new Vector3(-0.4f, 4, 0.7f);
                karakter.size= new Vector3(4, 8,7);
                StartCoroutine(slideWaith());
                

            }




            if (Swipemanager.swipeDown && !controller.isGrounded)
            {
                direction.y += Gravity;

            }




            if (Swipemanager.swipeRight && _menu.isStart)
            {
                
                desiredLine++;
                if (desiredLine == 3)
                {
                    desiredLine = 2;
                }
            }
            if (Swipemanager.swipeLeft && _menu.isStart)
            {
              
                desiredLine--;
                if (desiredLine == -1)
                {
                    desiredLine = 0;
                }
            }

            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (desiredLine == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLine == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }


           // transform.position = targetPosition;
           // controller.center = controller.center;
            //transform.position = Vector3.Lerp(transform.position, targetPosition,0.1f);
            
            if(transform.position == targetPosition)
            {
                return;
            }
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(moveDir);

            }
            else
            {
                controller.Move(diff);
            }

        }

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

     
    private void Jump()
    {
        direction.y = jumpForce;
        anim.SetTrigger("jumpt");
        anim.SetBool("slide", false);
         
    }


    IEnumerator slideWaith()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("slide", false);
        controller.height = 0.89f;
        controller.center = new Vector3(0, 0.51f, 0.06f);
        karakter.center = new Vector3(-0.4f, 8, 0.7f);
        karakter.size = new Vector3(4, 16, 7);
        //forwardSpeed = 300;
       
    }

}
