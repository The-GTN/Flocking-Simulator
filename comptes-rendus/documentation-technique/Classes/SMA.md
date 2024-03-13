# **| public class SMA : MonoBehaviour |** [**↩️ Accueil**](../doc.md) **|** [**⬅️ Utils**](Utils.md) **|** [**➡️ Agent**](./Agent.md) **|**


## **Descriptif**

Classe correspondant au Système de Simulation. Il hérite de Monobehaviour car il a un comportement en fonction du temps (variation des paramètres et activités des agents).

## **Attributs**

---

* public GameObject boid : GameObject donnant la forme aux Agents
* private List< [Agent](Agent.md) > agents : Liste des agents du système
* private Environnement env : Environnement du système
* public int population : population courante (gestion population)
* private int oldPopulation : ancienne population (gestion population)
* private static int MINPOP : population minimum (gestion population)
* private static int MAXPOP : population maximum (gestion population)
* public bool _3D : vrai si en 3D, dimension courante
* private bool _old3D : vrai si en 3D, ancienne dimension
* public float angle : angle de vision courant des agents (gestion vision agents)
* private float oldAngle : ancien angle de vision des agents (gestion vision agents)
* public float rayon : rayon courant de vision des agents (gestion vision agents)
* private float oldRayon : ancien rayon de vision des agents (gestion vision agents)
* public float kR : Coefficient k pour répulsion des Bords (gestion Bords)
* public float kT : Coefficient t pour mouvement en tangente (gestion Bords)
* public float speedSimulation : vitesse de la simulation
* public bool AllReynolds : vrai si zone d'influence des règles Reynolds sont des disques et non des arc de disques (gestion Reynolds)
* public float Escape : constante de distance de séparation (gestion Reynolds)
* public float EscapeWeight : poids de la séparation (gestion Reynolds)
* public float Together : constante de distance de l'alignement (gestion Reynolds)
* public float TogetherWeight : poids de l'alignement (gestion Reynolds)
* public float Follow : constante de distance de cohésion (gestion Reynolds)
* public float FollowWeight : poids de la cohésion (gestion Reynolds)
* public int currentObstacles : pattern courant d'obstacles (gestion obstacles)
* private int oldObstacles : ancien pattern d'obstacles (gestion obstacles)

---

## **Méthodes**

---

> public Environnement getEnvironnement() 

* return : l'environnement du système

---

> public List<[Observation](Vision/Observation.md)> getVoisinage([Agent](Agent.md) current, float rayon, float angle) 

* param current : agent qui perçoit son environnement
* param rayon : rayon de vision de l'agent
* param angle : angle de vision de l'agent
* return : la liste d'observations effectuées par l'agent current

---

> public List<[Agent](Agent.md)> getAgents() 

* return : la liste des agents du système

---

> void Start()

* effect : dû à l'héritage de MonoBehaviour, est appelé avant la première image affichée de la simulation. Initialise le système

---

> private void createEnvironnement()

* effect : associe l'environnement au système

---

> private void createAgents()

* effect : crée autant d'agents que l'effectif voulu par le système

---

> private void createAgents(int n)

* param n : le nombre d'agents à créer
* effect : crée n agents dans le système

---

> private void createAgent()

* effect : crée un agent dans le système

---

> private void createAgent(Vector3 pos)

* param pos : position à laquelle on souhaite créer l'agent
* effect : crée un agent dans le système à la position pos

---

> void Update()

* effect : dû à l'héritage de MonoBehaviour, est appelée à chaque affichage. Met à jour le système

---

> private void changeObstacles() 

* effect : changement du pattern obstacles selon attribut du système

---

> private void changeDimension() 

* effect : Change la dimension de l'environnement du système pour correspondre au booléen _3D

---

> private void resetAgents() 

* effect : supprime puis recrée les agents du système 

---

> private void removeAgents() 

* effect : supprime les agents du système

---

> private void changeReynolds()

* effect : met à jour les constantes Reynolds selon les constantes du sma

---

> private void changePopulation()

* effect : verifie les changement sur les agents selon les attributs du système

---

> private void changeBordConstant() 

* effect : mise à jour selon les attributs du système des constantes kR (repulsion) et kT (tangente) du calcul de gestion de bords

---

> private void changeEffectifPopulation() 

* effect : vérifie si l'effectif voulu par le système est respecté et modifie la population s'il le faut

---
 
> private void changeAngleRayonVision() 

* effect : vérifie si l'angle et le rayon de vision des agents voulues par le système sont respectés et les modifie si besoin

---
