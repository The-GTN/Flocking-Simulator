# **| public class Carre :** [**Cube**](Cube.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Cube**](./Cube.md) **|** [**➡️ Obstacle**](../Obstacle/Obstacle.md) **|**


## **Descriptif**

Classe pour une topologie d'environnement en forme de carré. Hérite de [Cube](Cube.md)

## **Méthodes**

---

> public Carre(Environnement e,GameObject c)

* param e : environnement auquel appartien la topologie
* param c : visuel de la topologie
* return : instance de la topologie

---

> public override [Observation](../../Vision/Observation.md) detectEnv([Agent](../../Agent.md) current);

* param current : agent qui détecte le bord de la topologie
* return : l'observation effectué par l'agent du point de la topologie que l'agent current pourrait heurter

---

> protected List< Vector3 > getExtremPositions([Agent](../../Agent.md) current)

* param current : l'agent dont on souhaite les projections de sa position sur les côtés du carré
* return : les projections de la position de l'agent sur les côtés du carré

---

> protected Vector3 basicAnswer(List< Vector3 > p, float x, float y, float z)

* param p : la liste des réponses basiques
* param x : composante en x du déplacement
* param y : composante en y du déplacement
* param z : composante en z du déplacement
* return : la position du point d'impact selon la direction unidirectionnel décrite par les composantes x, y et z 

---

> protected Vector3 goingToHit([Agent](../../Agent.md) current)

* param current : l'agent dont on veut le point d'impact avec l'environnement
* return : la position du point d'impact entre l'environnement et l'agent current 

---


> protected List<(Vector3,Vector3)> choiceMove(List< Vector3 > p, float x, float y,float z) 

* param p : la liste des positions des points des côtés (obtenus avec basicAnswer)
* param x : composante en x du déplacement
* param y : composante en y du déplacement
* param z : composante en z du déplacement
* return : les positions des points des côtés ainsi que les déplacements triviaux induit par le déplacement

---


