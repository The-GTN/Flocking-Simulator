// Monobehaviour + Vector3
using UnityEngine;
// List
using System.Collections.Generic;

// Classe correspondant à un agent boïd
public class Agent : MonoBehaviour, Visible
{

    // Attributs

    // système auquel l'agent appartient
    private SMA system;
    // comportement de l'agent
    private Comportement comportement;
    // perception de l'agent
    private Perception perception;

    // deplacement courant de l'agent
    public Vector3 deplacement;

    // nombre d'Agents créés
    private static int count = 0;
    // identifiant de l'agent;
    private int id;


    // Méthodes

    // renvoie le système auquel l'agent appartient
    public SMA getSystem() {
        return system;
    }

    // indique s'il est un Visible mobile
    public bool isAlive() { return true; }

    // utilise la perception p en tant que nouvelle perception de l'agent
    public void setPerception(Perception p) {
        perception = p;
    }

    // utilise le comportement c en tant que nouveau comportement de l'agent
    public void setComportement(Comportement c) {
        comportement = c;
    }

    // Start est appelé avant la première image affichée
    void Start()
    {
        system = GameObject.Find("SMA").GetComponent<SMA>();

        // début Comportement modifiable

        List<Comportement> comps = new List<Comportement> { 
            new TangenteBord2(this),new Reynolds(this), new Aleatoire(this)
        };
        List<int> imps = new List<int> { 
            10,10,1 
        };
        Comportement c =  new CompositeSum(this,comps,imps);

        // fin Comportement modifiable

        if(system._3D) comportement = c;
        else comportement = new Constrain2D(this,c);

        perception = new Perception180(this,20.0f);

        deplacement = Utils.randomDirection();

        id = Agent.count;
        Agent.count++;
    }

    // Update est appelée à chaque affichage
    void Update()
    {   
        reagir(voir());
    }

    // renvoie les observations effectuées par l'agent
    private List<Observation> voir() { return perception.voir(); }

    // réaction de l'agent en fonction de ses observations
    private void reagir(List<Observation> observation) {
        float norm = Utils.normVector(deplacement);
        deplacement = comportement.reagir(observation);
        deplacement = deplacement.normalized * norm;
        move();
    }
    
    // déplacement de l'agent
    private void move() {
        transform.position += (deplacement * system.speedSimulation);
        transform.LookAt(transform.position + deplacement);
    }

    // méthode de test d'égalité si l'agent est égal à l'objet obj
    public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Agent))
            {
                return false;
            }
            return (this.id == ((Agent) obj).id);
        }

    // renvoie le hashCode de l'agent
    public override int GetHashCode()
   {
      return id;
   }

}
