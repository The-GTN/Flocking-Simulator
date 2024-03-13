# **| public class Environnement : MonoBehaviour |** [**↩️ Accueil**](../../doc.md) **|** [**⬅️ Perception360**](../Perception/Perception360.md) **|** [**➡️ Topologie**](./Topologie/Topologie.md) **|**

## **Descriptif**

Classe correpondant à l'environnement du système. Hérite de Monobehaviour car il peut changer selon le système

## **Attributs**

---

* public GameObject cube : Visuel environnement en cube
* public GameObject carre : Visuel environnement en carré
* public GameObject[] figures : Visuels possibles pour les obstacles
* private [SMA](../SMA.md) system : système utilisant l'environnement
* private bool _3D : actuel dimension de l'environnement (vrai si 3D)
* private [Topologie](Topologie/Topologie.md) topologie : topologie de l'environnement
* private List<[CustomObstacle](Obstacle/CustomObstacle.md)> obstacles : liste des obstacles dans l'environnement

---

## **Méthodes**

---

> public [Topologie](Topologie/Topologie.md) getTopologie() 

* return : la topologie de l'environnement

---

> public Vector3 validPosition()

* return : une position valide dans l'environnement

---

> public float getMaxDistance() 

return : la distance maximale mesurable dans l'environnement

---

> public void notify()

* effect : change l'environnement en 3D ou non selon le système

---

> private void setTheTopologie([Topologie](Topologie/Topologie.md) topo) 

* param topo : topologie à utiliser pour l'environnement
* effect : Initialise l'environnement avec seulement son contour entré en paramètre

---

> public List<[Observation](../Vision/Observation.md)> getVoisinage([Agent](../Agent.md) current, float rayon, float angle)

* param current : agent dont on souhaite les observations
* param rayon : rayon de vision
* param angle : angle de vision
* return : liste des observations de l'agent dans l'environnement

---

> private List<[Observation](../Vision/Observation.md)> detectAgents([Agent](../Agent.md) current, float rayon, float angle)

* param current : agent dont on souhaite les observations
* param rayon : rayon de vision
* param angle : angle de vision
* return : liste des observations de l'agent d'autres dans l'environnement

---

> private List<[Observation](../Vision/Observation.md)> detectObstacles([Agent](../Agent.md) current, List<[Observation](../Vision/Observation.md)> res,float rayon) 

* param current : agent dont on souhaite les observations
* param res : liste des observations déjà effectuées
* param rayon : rayon de vision
* return : liste des observations d'obstacles ajoutée à la liste des observations déjà effectuées de l'agent dans l'environnement

---

> private List<[Observation](../Vision/Observation.md)> detectBord([Agent](../Agent.md) current, List<[Observation](../Vision/Observation.md)> res, float rayon, float angle) 

* param current : agent dont on souhaite les observations
* param res : liste des observations déjà effectuées
* param rayon : rayon de vision
* param angle : angle de vision
* return : liste des observations des bords ajoutée à la liste des observations déjà effectuées de l'agent dans l'environnement

---

> public void createObject(GameObject obj, Vector3 pos) 

* param obj : objet à créer
* param pos : position où on souhaite le créer
* effect : crée l'objet à la position souhaitée

---

> void Start()

* effect : dû à l'héritage de MonoBehaviour, est appelé avant la première image affichée de l'environnement. Initialise l'environnement.

---

> public List<[CustomObstacle](Obstacle/CustomObstacle.md)> getPattern(int i) 

* param i : indice du pattern à renvoyer
* return : un ième pattern d'obstacles 

---

> public void changeObstacles(List<[CustomObstacle](Obstacle/CustomObstacle.md)> co)

* param co : liste d'obstacles à associer à l'environnement
* effect : change les obstacles de l'environnement

---

> private void createObstacles()

* effect : crée les visuels des obstacles

---
