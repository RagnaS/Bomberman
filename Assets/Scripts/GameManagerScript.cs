//Braga Mickaël - 2013
using UnityEngine;
using System.Collections;



public class GameManagerScript : MonoBehaviour
{

    private GenerationAleatoireTerrainScript terre;
    public GenerationAleatoireTerrainScript Terre
    {
        get
        {
            return this.terre;
        }
        set
        {
            terre = value;
        }
    }


    public GameObject[] Player;
    public int nbjoueurs = 2; //nombres de joueur


    void Awake()
    {

    }

    void Start()
    {
        Player = new GameObject[nbjoueurs];
        Terre = GetComponent<GenerationAleatoireTerrainScript>();
        CreationJoueur(); // fonction de création des joueurs
        
    }


    void Update()
    {
        int compt = nbjoueurs;

        for (int i = 0; i < Player.Length; i++)
        { 
                if(Player[i] == null)
                {
                    compt--;

                }
        
        }

        if (compt == 1)
        {
            Application.LoadLevel(0);
        }


    }




    void CreationJoueur() // fonction de création des équipes
    {

        for (int l = 0; l < nbjoueurs; l++)
        {
            if (l == 0)
            {
                Player[l] = GameObject.Instantiate(Resources.Load("Char_1",typeof(GameObject))) as GameObject; 
                Player[l].transform.position = new Vector3(-(Terre.Taillemap/4) + 2f,1.5f,(Terre.Taillemap/4) - 2);
            }

            if (l == 1)
            {
                Player[l] = GameObject.Instantiate(Resources.Load("Char_2", typeof(GameObject))) as GameObject; 
                Player[l].transform.position = new Vector3((Terre.Taillemap / 4) - 2f, 1.5f, -(Terre.Taillemap / 4) + 2);
            }

            if (l == 2)
            {
                Player[l] = GameObject.Instantiate(Resources.Load("Char_3", typeof(GameObject))) as GameObject;
                Player[l].transform.position = new Vector3(-(Terre.Taillemap / 4) + 2f, 1.5f, -(Terre.Taillemap / 4) + 2);
            }

            if (l == 3)
            {
                Player[l] = GameObject.Instantiate(Resources.Load("Char_4", typeof(GameObject))) as GameObject;
                Player[l].transform.position = new Vector3((Terre.Taillemap / 4) - 2f, 1.5f, (Terre.Taillemap / 4) - 2);
            }

        }



    }

}
