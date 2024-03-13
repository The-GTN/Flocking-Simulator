# **| public abstract class Topologie |** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Environnement**](../Environnement.md) **|** [**➡️ Cube**](./Cube.md) **|**

## **Descriptif**

Classe abstraite pour la topologie d'un environnement


## **Attributs**

---

* protected [Environnement](../Environnement.md) environnement : Environnement auquel appartient la topologie

---

## **Méthodes**


---

> public Topologie([Environnement](../Environnement.md) env)

* param env : environnement auquel appartien la topologie
* return : l'instance de Topologie

---

> public abstract GameObject getGameObject();

* return : le GameObject de la topologie

---

> public abstract [Observation](../../Vision/Observation.md) detectEnv([Agent](../../Agent.md) current);

* param current : agent qui détecte le bord de la topologie
* return : l'observation effectué par l'agent du point de la topologie que l'agent current pourrait heurter

---

> public abstract Vector3 validPosition();

* return : une position valide dans la topologie

---

> public abstract bool isValidPosition(Vector3 pos);

* param pos : une position
* return : si la position est valide dans la topologie

---

> public abstract float getMaxDistance();

* return : la distance maximale mesurable dans la topologie

---
