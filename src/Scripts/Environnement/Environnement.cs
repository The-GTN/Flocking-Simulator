// Monobehaviour + Vector3
using UnityEngine;
// List
using System.Collections.Generic;

// Classe correpondant à l'environnement du système
public class Environnement : MonoBehaviour
{

    // Attributs

    // Visuel environnement en cube
    public GameObject cube;
    // Visuel environnement en carré
    public GameObject carre;
    // Visuel possible pour les obstacles
    public GameObject[] figures;

    // système utilisant l'environnement
    private SMA system;
    // actuel dimension de l'environnement
    private bool _3D;
    // topologie de l'environnement
    private Topologie topologie;
    // liste des obstacles dans l'environnement
    private List<CustomObstacle> obstacles;


    // Méthodes

    // renvoie la topologie de l'environnement
    public Topologie getTopologie() {
        return topologie;
    }

    // renvoie une position valide dans l'environnement
    public Vector3 validPosition() {
        return topologie.validPosition();
    }

    // renvoie la distance maximale mesurable dans l'environnement
    public float getMaxDistance() {
        return topologie.getMaxDistance();
    }

    // change l'environnement en 3D ou non selon le système
    public void notify() {
        if(_3D != system._3D) {
            _3D = system._3D;
            if(_3D) setTheTopologie(new Cube(this,cube));
            else setTheTopologie(new Carre(this,carre));
            createObstacles();
        } 
    }

    // Initialise l'environnement avec seulement son contour entré en paramètre
    private void setTheTopologie(Topologie topo) {
        foreach (Transform child in transform) Destroy(child.gameObject);
        topologie = topo;
        createObject(topologie.getGameObject(), Vector3.zero);
    }

    // renvoie le voisinage de l'agent current dans cet environnement selon un rayon et un angle de vue
    public List<Observation> getVoisinage(Agent current, float rayon, float angle) {
        List<Observation> res = detectAgents(current,rayon,angle);
        res = detectObstacles(current,res,rayon);
        return detectBord(current,res,rayon,angle);
    }

    // renvoie la liste des observations d'agents faites par l'agent current
    private List<Observation> detectAgents(Agent current, float rayon, float angle) {
        Vector3 dist; float l; float a;
        List<Observation> res = new List<Observation>();
        List<Agent> agents = system.getAgents();
        RaycastHit[] hits;Ray ray;
        Vector3 pos = current.transform.position;
        bool notSeen;
        for(int i = 0; i<agents.Count;i++) {
            dist = agents[i].transform.position - pos;
            ray = new Ray(pos,dist);
            l = Utils.normVector(dist);
            a = Vector3.Angle(current.deplacement,dist);
            notSeen = false;
            if (agents[i] != current && l <= rayon && a <= angle/2.0f) {
                hits = Physics.RaycastAll(ray, rayon);
                for(int j = 0; j<hits.Length;j++)
                    if(hits[j].transform.GetComponent<Agent>() == null) 
                        if(hits[j].distance < l) notSeen = true;
                
                if(!notSeen)res.Add(new Observation(agents[i],dist));
            }
        }
        return res;
    }

    // ajoute la liste des observations des obstacles à la liste d'observations faites par l'agent current
    private List<Observation> detectObstacles(Agent current, List<Observation> res,float rayon) {
        Vector3 pos = current.transform.position;
        bool notSeen = true;
        int k = 0;
        Ray ray = new Ray(pos,current.deplacement);
        RaycastHit[] hits = Physics.RaycastAll(ray, rayon);
        List<Vector3> tangentes = new List<Vector3> {
            Quaternion.Euler(-90, 0, 0) * current.deplacement, Quaternion.Euler(90, 0, 0) * current.deplacement,
            Quaternion.Euler(0, -90, 0) * current.deplacement, Quaternion.Euler(0, 90, 0) * current.deplacement,
            Quaternion.Euler(0, 0, -90) * current.deplacement, Quaternion.Euler(0, 0, 90) * current.deplacement
        };

        while(k < hits.Length && notSeen) {
            if(hits[k].transform.GetComponent<Agent>() == null) {
                res.Add(new Observation(new PointObstacle(this,hits[k].point,tangentes),hits[k].point-pos));
                notSeen = false;
            }
            k++;
        }
        return res;
    }

    // ajoute la liste des observations des bords de l'environnement à la liste d'observations faites par l'agent current
    private List<Observation> detectBord(Agent current, List<Observation> res, float rayon, float angle) {
        float l, a;
        Observation bord = topologie.detectEnv(current);
        l = Utils.normVector(bord.distance); a = Vector3.Angle(current.deplacement,bord.distance);
        if(l <= rayon && a <= angle/2.0f) res.Add(bord);
        return res;
    }

    // permet de créer un objet dans l'environnement
    public void createObject(GameObject obj, Vector3 pos) {
        Instantiate(obj,pos,Quaternion.identity,transform);
    }

    // Start est appelé avant la première image affichée
    void Start()
    {
        system = GameObject.Find("SMA").GetComponent<SMA>();
        _3D = !system._3D;
        obstacles = getPattern(0);
        notify(); 
    }

    // renvoie un ieme pattern d'obstacles, si non défini alors renvoie une liste vide
    public List<CustomObstacle> getPattern(int i) {
        if (i == 1) {
            return new List<CustomObstacle> {
                new CustomObstacle(this,new Vector3(-20.0f,20.0f,0.0f),figures[Utils.random(0,figures.Length)]), 
                new CustomObstacle(this,new Vector3(20.0f,-20.0f,0.0f),figures[Utils.random(0,figures.Length)]) };
        }
        else return new List<CustomObstacle>();
    }

    // change les obstacles de l'environnement
    public void changeObstacles(List<CustomObstacle> co) {obstacles = co;}

    // crée les visuels des obstacles
    private void createObstacles() {
        for(int i = 0; i<obstacles.Count;i++) obstacles[i].createObject();
    }

}
