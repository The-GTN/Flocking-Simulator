# **| public class CompositeSum :** [**Comportement**](../Base/Comportement.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ TangenteBord2**](../Bord/TangenteBord2.md) **|** [**➡️ CompositeMean**](./CompositeMean.md) **|**

## **Descriptif**

Classe pour comportement composé et qui somme ses composants. Hérite de [Comportement](../Base/Comportement.md)

## **Attributs**

---

* protected List<[Comportement](../Base/Comportement.md)> comportements : liste des comportements qui compose notre comportement
* protected List< int > importances : liste des poids d'importances des comportements

---

## **Méthodes**

---

> public CompositeSum([Agent](../../Agent.md) proprietaire,List<[Comportement](../Base/Comportement.md)> c,List< int > i)

* param a : agent proprietaire du comportement
* param c : liste de comportement pour composer
* param i : liste des poids d'importances des comportements de la liste c
* return : instance de comportement

---

> public CompositeSum([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public void removeComportement(int i)

* param i : indice du comportement à enlever
* effect : enlève le ième comportement du comportement composé

---

> public void AddComportement([Comportement](../Base/Comportement.md) c, int i)

* param c : comportement à ajouter
* param i : son poids d'importance
* effect : rajoute le comportement avec son poids dans le comportement composé

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---
