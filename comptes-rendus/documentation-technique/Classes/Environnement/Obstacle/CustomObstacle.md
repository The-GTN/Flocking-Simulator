# **| public class CustomObstacle :** [**Obstacle**](./Obstacle.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ PointObstacle**](./PointObstacle.md) **|** [**➡️ Comportement**](../../Comportement/Base/Comportement.md) **|**


## **Descriptif**

Classe pour un obstacle avec un visuel défini. Hérite de [Obstacle](./Obstacle.md)

## **Attributs**

---

* public GameObject figure : l'esthetique de l'obstacle

---

# **Méthodes**

---

> public CustomObstacle([Environnement](../Environnement.md) e, Vector3 p,GameObject g)

* param e : environnement auquel l'Obstacle appartient
* param p : position de l'obstacle
* param g : le visuel de l'obstacle
* return : instance d'obstacle avec un visuel particulier
   
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

}
