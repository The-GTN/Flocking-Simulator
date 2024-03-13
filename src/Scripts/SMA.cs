// pour le Monobehaviour + Vector3
using UnityEngine;
// pour utiliser List
using System.Collections.Generic;

// Classe correspondant au Système
public class SMA : MonoBehaviour
{

    // Attributs

    // GameObject donnant la forme aux Agents
    public GameObject boid;

    // Liste des agents du système
    private List<Agent> agents = new List<Agent>();
    // Environnement du système
    private Environnement env;
    
    // Effectif de la population du système
    // population courante
    public int population = 1;
    // ancienne population
    private int oldPopulation = 1;
    // population minimum
    private static int MINPOP = 0;
    // population maximum
    private static int MAXPOP = 500;

    // Booléen vérifiant si le système est en trois dimensions
    // dimension courante
    public bool _3D = true;
    // ancienne dimension
    private bool _old3D = true;

    // Angle de vision des agents du système
    // angle courant
    public float angle = 250.0f;
    // ancien angle
    private float oldAngle = 180.0f;

    // Rayon de vision des agents du système
    // rayon de vision courant
    public float rayon = 20.0f;
    // ancien rayon de vision
    private float oldRayon = 20.0f;

    // Coefficient k pour répulsion des Bords (+ élevé = + répulsion + loin du bord)
    public float kR = 50.0f;
    // Coefficient t pour mouvement en tangente
    public float kT = 5.0f;

    // Vitesse de la simulation
    public float speedSimulation = 1.0f;

    // test fonctionnement reynold
    public bool AllReynolds = true;

    // constante de distance de séparation
    public float Escape = 8.0f;
    // poids de la séparation
    public float EscapeWeight = 1.0f;
    // constante de distance de l'alignement 
    public float Together = 13.0f;
    // poids de l'alignement
    public float TogetherWeight = 1.0f;
    // constante de distance de cohésion
    public float Follow = 30.0f;
    // poids de la cohésion
    public float FollowWeight = 1.0f;

    // gestion pattern d'obstacles
    // pattern courant d'obstacles
    public int currentObstacles = 0;
    // ancien pattern d'obstacles
    private int oldObstacles = 0;


    // Méthodes

    // renvoie l'environnement du système
    public Environnement getEnvironnement() {
        return env;
    }

    // renvoie le voisinage de l'agent current dans l'environnement du système selon un rayon et un angle de vue
    public List<Observation> getVoisinage(Agent current, float rayon, float angle) {
        return env.getVoisinage(current,rayon,angle);
    }

    // renvoie la liste des agents du système
    public List<Agent> getAgents() {
        return agents;
    }

    // Start est appelé avant la première image affichée
    void Start()
    {
        createEnvironnement();
        createAgents();
    }

    // associe l'environnement du système
    private void createEnvironnement() {
        env = GameObject.Find("Environnement").GetComponent<Environnement>();
    }

    // crée autant d'agents que l'effectif voulu par le système
    private void createAgents() {
        createAgents(population);
    }

    // crée n agents dans le système
    private void createAgents(int n) {
        for(int i=0; i<n; i++) createAgent();
    }

    // crée un agent dans le système
    private void createAgent() {
        GameObject a;
        a = Instantiate(boid, env.validPosition(), Quaternion.identity,env.transform) as GameObject;
        agents.Add(a.GetComponent<Agent>());
    }

    // crée un agent dans le système à la position pos
    private void createAgent(Vector3 pos) {
        GameObject a; Agent agent;
        a = Instantiate(boid, pos, Quaternion.identity,env.transform) as GameObject;
        agent = a.GetComponent<Agent>();
        agents.Add(agent);
    }

    // Update est appelée à chaque affichage
    void Update()
    {
        changeObstacles();
        changeDimension();
        changeReynolds();
        changePopulation();
    }

    // changement pattern obstacles
    private void changeObstacles() {
        if(currentObstacles != oldObstacles || _3D != _old3D) {
            oldObstacles = currentObstacles;
            env.changeObstacles(env.getPattern(currentObstacles));
        }
    }

    // Change la dimension de l'environnement du système pour correspondre au booléen _3D
    private void changeDimension() {
        if (_3D != _old3D) {
            _old3D = _3D;
            resetAgents();
        }
    }

    // supprime puis recrée les agents du système
    private void resetAgents() {
        removeAgents();
        createAgents();
    }

    // supprime les agents du système
    private void removeAgents() {
        agents.Clear();
        for(int i = 0; i<2; i++) {
            _3D = !_3D;
            env.notify();
        }
    }

    // met à jour les constantes Reynolds selon les constantes du sma
    private void changeReynolds() {
        if(Escape != Reynolds.Escape) Reynolds.Escape = Escape;
        if(EscapeWeight != Reynolds.EscapeWeight) Reynolds.EscapeWeight = EscapeWeight;
        if(Together != Reynolds.Together) Reynolds.Together = Together;
        if(TogetherWeight != Reynolds.TogetherWeight) Reynolds.TogetherWeight = TogetherWeight;
        if(Follow != Reynolds.Follow) Reynolds.Follow = Follow;
        if(FollowWeight != Reynolds.FollowWeight) Reynolds.FollowWeight = FollowWeight;
    }

    // verifie les changement sur les agents
    private void changePopulation() {
        changeBordConstant();
        changeEffectifPopulation();
        changeAngleRayonVision();
    }

    // mise à jour si besoin de la constante kR (repulsion) du calcul de gestion de bords
    private void changeBordConstant() { 
        if (kR != Bord.kR) Bord.kR = kR; 
        if (kT != TangenteBord2.kT) TangenteBord2.kT = kT;
    }

    // vérifie si l'effectif voulu par le système est respecté et modifie la population s'il le faut
    private void changeEffectifPopulation() {
        if(population < MINPOP) population = MINPOP;
        if(population > MAXPOP) population = MAXPOP;
        if(oldPopulation != population) {
            if(oldPopulation < population) createAgents(population - oldPopulation);
            else {
                removeAgents();
                createAgents(population);
            }
            oldPopulation = population;
        }
    }

    // vérifie si l'angle et le rayon de vision des agents voulues par le système sont respectés et les modifie si besoin 
    private void changeAngleRayonVision() {
        if (oldAngle != angle || oldRayon != rayon) {
            for(int i=0; i < agents.Count; i++) agents[i].setPerception(new Perception(agents[i],rayon,angle));
        }
    }

}