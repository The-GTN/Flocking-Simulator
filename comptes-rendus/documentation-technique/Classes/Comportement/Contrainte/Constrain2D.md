# **| public class Constrain2D :** [**Comportement**](../Base/Comportement.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ CompositeMean**](../Composite/CompositeMean.md) **|** [**➡️ Reynolds**](../Papers/Reynolds.md) **|**

## **Descriptif**

Classe pour comportement contraignant un comportement à un mouvement 2D. Hérite de [Comportement](../Base/Comportement.md)

## **Attributs**

---

* protected Comportement comportement :  le comportement qui est contraint

---

## **Méthodes**

---

> public Constrain2D(Agent proprietaire,Comportement c)

* param a : agent proprietaire du comportement
* param c : comportement à contraindre
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---