# **| public class PointObstacle :** [**Obstacle**](./Obstacle.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Obstacle**](./Obstacle.md) **|** [**➡️ CustomObstacle**](./CustomObstacle.md) **|**


## **Descriptif**

Classe pour un obstacle en un point. Hérite de [Obstacle](./Obstacle.md)

## **Attributs**

---

* public List< Vector3 > tangentes : les tangentes au point

---

# **Méthodes**

---

> public PointObstacle([Environnement](../Environnement.md) e, Vector3 p, List<Vector3> t)

* param e : environnement auquel l'Obstacle appartient
* param p : position de l'obstacle
* param t : tangentes au point
* return : instance de point d'obstacle

---

> public PointObstacle([Environnement](../Environnement.md) e, Vector3 p)

* param e : environnement auquel l'Obstacle appartient
* param p : position de l'obstacle
* return : instance de point d'obstacle
   
---

> public override Vector3 getPointContact([Agent](../../Agent.md) a);

* param a : agent qui rentrerait en contact avec l'obstacle
* return : position du point auquel l'agent rentrerait en collision avec l'obstacle

---

> public override List< Vector3 > getTangentes([Agent](../../Agent.md) a);

* param a : agent qui rentrerait en contact avec l'obstacle
* return : les tangentes au point d'impact entre l'agent et l'obstacle

---

> public override void createObject(); 

* effect : crée le visuel de l'obstacle dans l'environnement

---
