# **| public abstract class Obstacle :** [**Visible**](../../Vision/Visible.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Carre**](../Topologie/Carre.md) **|** [**➡️ PointObstacle**](./PointObstacle.md) **|**


## **Descriptif**

Classe abstraite correspondant à un Obstacle dans un environnement. Implémente [Visible](../../Vision/Visible.md)

# **Attributs**

---

* public Vector3 position : position de l'objet
* protected [Environnement](../Environnement.md) env : environnement de l'objet

---

## **Méthodes**

---

> public Obstacle([Environnement](../Environnement.md) e, Vector3 p)

* param e : environnement auquel l'Obstacle appartient
* param p : position de l'obstacle
* return : instance d'obstacle

---

> public bool isAlive()

* return : si l'objet visible est mobile ou non

---

> public abstract Vector3 getPointContact([Agent](../../Agent.md) a);

* param a : agent qui rentrerait en contact avec l'obstacle
* return : position du point auquel l'agent rentrerait en collision avec l'obstacle

---

> public abstract List< Vector3 > getTangentes([Agent](../../Agent.md) a);

* param a : agent qui rentrerait en contact avec l'obstacle
* return : les tangentes au point d'impact entre l'agent et l'obstacle

---

> public abstract void createObject(); 

* effect : crée le visuel de l'obstacle dans l'environnement

---
