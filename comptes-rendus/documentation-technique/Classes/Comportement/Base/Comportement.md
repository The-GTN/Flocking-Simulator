# **| public abstract class Comportement |** [**↩️ Accueil**](../doc.md) **|** [**⬅️ CustomObstacle**](../../Environnement/Obstacle/CustomObstacle.md) **|** [**➡️ Constant**](./Constant.md) **|**

## **Descriptif**

Classe abstraite correspondant au comportement d'un agent

## **Attributs**

---

* protected [Agent](../../Agent.md) proprietaire : le proprietaire du comportement

---

## **Méthodes**

---

> public Comportement([Agent](../../Agent.md) a)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public abstract Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---
