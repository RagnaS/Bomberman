//Braga Mickaël - 2013
using UnityEngine;
using System.Collections;

public class Bombes : MonoBehaviour {

    [SerializeField]
	public bool valid;
    private GameObject bombe;
    [SerializeField]
    private float timer;
	public ParticleSystem pe;
    private Ray ray;


    public GameObject Bombe
    {
        get { return bombe; }
        set { bombe = value; }
 
    }

	// Use this for initialization
	void Start () 
    {

		valid = true;
        timer = 2f;
        ray = new Ray();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(valid == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Explosion();
            }
        }
        


       
	}

	void Explosion()
	{

        ApplyRaycast();
           
		
		Destroy(this.gameObject);
		
		
	}

    void ApplyRaycast()
    {
        ApplyRayhit(this.transform, Vector3.right);
        ApplyRayhit(this.transform, Vector3.forward);
        ApplyRayhit(this.transform, Vector3.back);
        ApplyRayhit(this.transform, Vector3.left);
        

    }

    void ApplyRayhit(Transform origin, Vector3 direction)
    {
        ray.origin = origin.position;
        ray.direction = direction;

        RaycastHit hit;

        if (Physics.Raycast( ray, out hit, 3f))
        {
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.name == "Cube(Clone)")
            {
                Destroy(hit.collider.gameObject);
                Debug.Log(hit.collider.gameObject.name);

            }

        }
     


    }
}
