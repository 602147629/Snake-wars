using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float speed = 3;  
    Transform current;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject HeadSnake;
    Tail tail, tailTail;
    private int lengthTail = 0;
    private Vector3 rotate;
    public Quaternion rot = Quaternion.identity;
    public GameObject BodyTail;
    private int numberFood;
    public int bonus = 1;
    public Text text;
    public float valueSpeed;

    public int points = 10;

    public float rotationSpeed = 60;

    private CharacterController _controller;

    public void Start()
    {
        if (SelectIntricacy.intricacy == "easy")
        {
            setPositionAndSpeed(-7.37f, 0.77f, -0.11f, 0.1f);
        }
        else if (SelectIntricacy.intricacy == "average")
        {
            setPositionAndSpeed(-14f, 0.77f, 14f, 0.2f);       
        }
        else if (SelectIntricacy.intricacy == "complex")
        {
            setPositionAndSpeed(-6f, 0.77f, 6f, 0.3f);
        }
        _controller = GetComponent<CharacterController>();

        _controller.Move(rotate * speed * Time.deltaTime);
         current = transform;
    }

    private void setPositionAndSpeed(float x, float y, float z, float speed)
    {
        HeadSnake.transform.position = new Vector3(x, y, z);
        valueSpeed = speed;
    }

    private bool _testing = false;

    public void Update()
    {
        if (SelectCamera.typeCam == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * horizontal);
            _testing = true; 
            _controller.Move(-transform.forward * speed * Time.deltaTime);
        }

        if (SelectCamera.typeCam == false)
        {
            _controller.Move(rotate * speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rotateByCoords(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rotateByCoords(0, 180, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotateByCoords(0, 270, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rotateByCoords(0, 90, 0);
            }
        }
    }

    public void rotateByCoords(int x, int y, int z)
    {
        rotate = -transform.right;
        rot.eulerAngles = new Vector3(x, y, z);
        HeadSnake.transform.rotation = rot;
    }
    
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);

        string nameFood = col.gameObject.name;
        numberFood = FoodUtils.foodWork(nameFood);
            if (numberFood == int.Parse(Game.numberCombination[0].ToString()))
                bonus++;
            else
                bonus = 1;

            Game.points += points * bonus;
            text.text = bonus.ToString();

        Food food = col.collider.GetComponent<Food>();

        numberFood = FoodUtils.foodWork(nameFood);

        if (numberFood < 11)
        {

            for (int i = 0; i < 10; i++)
            {
                if (int.Parse((Game.numberCombination[i]).ToString()) == numberFood)
                {
                    Debug.Log(int.Parse((Game.numberCombination[i]).ToString()));
                    Game.numberCombination = Game.numberCombination.Remove(i, 1);
                    break;
                }
            }
            lengthTail++;
         
            if (lengthTail == 1)
            {
                GameObject TailEnd = (GameObject)Instantiate(Resources.Load("Prefabs/TailPrefub"));                          
                tailTail = TailEnd.AddComponent<Tail>();

                Vector3 pos = tailTail.transform.GetChild(0).position;
                pos.x += 0.31f;
                tailTail.transform.GetChild(0).position = pos;

                tailTail.transform.rotation = transform.rotation;
                tailTail.target = current.transform;
                tailTail.targetDistance = 0.1f;
            }
            else if (lengthTail == 2)
            {
                setTailParameters("Prefabs/BodyPrefub", 2.4f);
                
                tailTail.transform.rotation = transform.rotation;
                tailTail.target = current.transform;
                tailTail.targetDistance = 0.01f;
            }
            else
            {
                setTailParameters("Prefabs/BodyPrefub", 2f);

                tailTail.transform.position = current.transform.position - current.transform.forward * 2;
                tailTail.transform.rotation = transform.rotation;
                tailTail.target = current.transform;
                tailTail.targetDistance = 0.1f;
            }
            Debug.Log(current);

            speed = speed + valueSpeed; ;
        }
        else
        {
            if (Life1 != null)
            {                
                Destroy(Life1);
                HeadSnake.transform.position = getPositionByDificulty();
            }
            else if (Life2 != null)
            {
                Destroy(Life2);
                HeadSnake.transform.position = getPositionByDificulty();
            }
            else if (Life3 != null)
            {
                Destroy(Life3);
                HeadSnake.transform.position = getPositionByDificulty();
            }
            else
            Application.LoadLevel("GameOver");
        }
    }

    private Vector3 getPositionByDificulty()
    {
        if (SelectIntricacy.intricacy == "easy")
            return new Vector3(-7.37f, 0.77f, -0.11f);
        else if (SelectIntricacy.intricacy == "average")
            return new Vector3(-14f, 0.77f, 14f);
        else if (SelectIntricacy.intricacy == "complex")
            return new Vector3(-6f, 0.77f, 6f);
        return new Vector3(0f, 0f, 0f);
    }

    private void setTailParameters(String prefub, float targetDistance)
    {
        GameObject BodyTail = (GameObject)Instantiate(Resources.Load(prefub));
        tail = BodyTail.AddComponent<Tail>();
        tail.transform.position = current.transform.position - current.transform.forward * 2;
        tail.transform.rotation = transform.rotation;
        tail.target = current.transform;
        tail.targetDistance = targetDistance;
        current = tail.transform;
    }

    public void rotateLeft()
    {
        _controller.Move(rotate * speed * Time.deltaTime);
        rotateByCoords(0, 270, 0);
    }

    public void rotateRight()
    {
        _controller.Move(rotate * speed * Time.deltaTime);
        rotateByCoords(0, 90, 0);
    }

    public void rotateUp()
    {
        _controller.Move(rotate * speed * Time.deltaTime);
        rotateByCoords(0, 0, 0);
    }

    public void rotateDown()
    {
        _controller.Move(rotate * speed * Time.deltaTime);
        rotateByCoords(0, 180, 0);
    }
}