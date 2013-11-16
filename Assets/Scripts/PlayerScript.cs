//Braga Mickaël - 2013
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


    private bool up;
    private bool down;
    private bool left;
    private bool right;
    private float vitesse = 4f;
    [SerializeField]
    private GameObject bombe;
    private Ray ray;
    private RaycastHit hit;

    public RaycastHit Hit
    {
        get { return hit; }
        set { hit = value; }
    }
    public Ray Ray
    {
        get { return ray; }
        set { ray = value; }
    }
    public GameObject Bombe
    {
        get { return bombe; }
        set { bombe = value; }
    }
    public bool Up
    {
        get { return up; }
        set { up = value; }
    }
    public bool Down
    {
        get { return down; }
        set { down = value; }
    }
    public bool Left
    {
        get { return left; }
        set { left = value; }
    }
    public bool Right
    {
        get { return right; }
        set { right = value; }
    }

	// Use this for initialization
	void Start ()
    {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
        Ray = new Ray();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Up = true;
            Down = false;
            Left = false;
            Right = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Up = false;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Up = false;
            Down = true;
            Left = false;
            Right = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Down =false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Up = false;
            Down = false;
            Left = true;
            Right = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Left = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Up = false;
            Down = false;
            Left = false;
            Right = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Right = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Detection("up"))
            {
                MettreBombe("up");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Detection("down"))
            {
                MettreBombe("down");
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Detection("left"))
            {
                MettreBombe("left");
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Detection("right"))
            {
                MettreBombe("right");
            }
        }

	}

    void FixedUpdate()
    {
        if (Up == true)
        {
            this.transform.Translate(Vector3.forward * vitesse * Time.deltaTime);
        
        }

        if (Down == true)
        {
            this.transform.Translate(Vector3.back * vitesse * Time.deltaTime);

        }

        if (Left == true)
        {
            this.transform.Translate(Vector3.left * vitesse * Time.deltaTime);

        }

        if (Right == true)
        {
            this.transform.Translate(Vector3.right * vitesse * Time.deltaTime);

        }
        
    
    }

    bool Detection(string Direction)
    {
        ray.origin = this.transform.position;

        if (Direction == "up")
        { ray.direction = Vector3.forward; }

        if (Direction == "down")
        { ray.direction = Vector3.back; }

        if (Direction == "left")
        { ray.direction = Vector3.left; }

        if (Direction == "right")
        { ray.direction = Vector3.right; }

        if (Physics.Raycast(ray, out hit, 1f))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void MettreBombe(string Direction)
    {
        Bombe = GameObject.Instantiate(Resources.Load("Bombe_Basic", typeof(GameObject))) as GameObject;

        if (Direction == "up")
        { 
            Bombe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1); 
        }

        if (Direction == "down")
        { 
            Bombe.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1); 
        }

        if (Direction == "left")
        {
            Bombe.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z); 
        }

        if (Direction == "right")
        { 
            Bombe.transform.position = new Vector3(this.transform.position.x + 1 , this.transform.position.y, this.transform.position.z); 
        }

        Bombe.SetActive(true);
        
        
    }

}
