# **| public class Cube :** [**Topologie**](Topologie.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Topologie**](./Topologie.md) **|** [**➡️ Carre**](./Carre.md) **|**


## **Descriptif**

Classe pour une topologie d'environnement en forme de cube. Hérite de [Topologie](Topologie.md)

## **Attributs**

* protected float minX : borne inférieur en x
* protected float maxX : borne maximum en x
* protected float minY : borne inférieur en y
* protected float maxY : borne maximum en y
* protected float minZ : borne inférieur en z
* protected float maxZ : borne maximum en z
* protected GameObject cube : visuel du cube 

# **Méthodes**

---

> public Cube([Environnement](../Environnement.md) e, GameObject c)

* param e : environnement auquel appartien la topologie
* param c : visuel de la topologie
* return : instance de la topologie

---

> public List< float > getExtremums()

* return : la liste des limites du cube dans cet ordre [minX,maxX,minY,maxY,minZ,maxZ] 

---

> public override GameObject getGameObject()

* return : le GameObject de la topologie

---

> public override [Observation](../../Vision/Observation.md) detectEnv([Agent](../../Agent.md) current);

* param current : agent qui détecte le bord de la topologie
* return : l'observation effectué par l'agent du point de la topologie que l'agent current pourrait heurter


---

> public override Vector3 validPosition();

* return : une position valide dans la topologie

---

> public override bool isValidPosition(Vector3 pos);

* param pos : une position
* return : si la position est valide dans la topologie

---

> public override float getMaxDistance();

* return : la distance maximale mesurable dans la topologie

---

> protected Vector3 convertToValidOne(Vector3 v) 

* param v : vecteur à convertir en un valide selon la topologie
* return : la position v de tel sorte à ce qu'elle soit valide dans le cube 

---

> protected bool onlyOneDirection(float x, float y, float z) 

* param x : composante en x du déplacement
* param y : composante en y du déplacement
* param z : composante en z du déplacement
* return : si le déplacement en x, y et z est unidirectionnel 

---

> protected Vector3 bestOne([Agent](../../Agent.md) current,Vector3 p1,Vector3 p2)

* param p1 : 1ere position d'impact
* param p2 : 2eme position d'impact
* return : la position d'impact d'environnement entre p1 et p2 qui est la plus adapté pour l'agent current 
    
---
