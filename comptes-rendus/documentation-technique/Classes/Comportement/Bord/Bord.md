# **| public class Bord :** [**Comportement**](../Base/Comportement.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Aleatoire**](../Base/Aleatoire.md) **|** [**➡️ TangenteBord1**](./TangenteBord1.md) **|**


## **Descriptif**

Classe correspondant à un comportement de gestion de Bord. Hérite de [Comportement](../Base/Comportement.md)


## **Attributs**

---

* static public float kR : constante de force de répulsion

---


## **Méthodes**

---

> public Bord([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---

> protected virtual Vector3 answer([Observation](../../Vision/Observation.md) o)

* param o : observation effectuée
* return : le vecteur réponse à l'observation

---

> protected virtual float delta(Vector3 d)

* param d : distance de l'observation
* return : force de la réponse

---