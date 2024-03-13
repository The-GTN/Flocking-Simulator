# **| public class Reynolds :** [**Comportement**](../Base/Comportement.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Constrain2D**](../Contrainte/Constrain2D.md) **|** [**➡️ Paper**](./Paper.md) **|**

## **Descriptif**

Classe pour comportement respectant les règles de nuées de [Reynolds](../../../../../media/reynolds.pdf). Hérite de [Comportement](../Base/Comportement.md)


## **Attributs**

---

* static public float Escape  : constante de distance de séparation
* static public float EscapeWeight : poids de la séparation
* static public float Together  : constante de distance de l'alignement 
* static public float TogetherWeight : poids de l'alignement
* static public float Follow  : constante de distance de cohésion
* static public float FollowWeight : poids de la cohésion

---

## **Méthodes**

---

> public Reynolds([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---
    
> private bool danger(Observation o)

* param o : observation effectué
* return : si il faut appliquer la règle d'éloignement

---

> private Vector3 fuir(Vector3 d)

* param d : distance qu'il faut fuir
* return : vecteur d'éloignement

---

> private bool normal(Observation o)

* param o : observation effectué
* return : si il faut appliquer la règle d'alignement

---

> private Vector3 suivre(Visible a)

* param a : visible observé et qu'il faut suivre
* return : vecteur d'alignement

---

> private bool isolement(Observation o)

* param o : observation effectué
* return : si il faut appliquer la règle de cohésion

---

> private Vector3 rapprocher(Vector3 d)

* param d : distance dont il faut se rapprocher
* return : vecteur de cohésion

---
