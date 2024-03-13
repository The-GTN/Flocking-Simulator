# **| public class CompositeMean :** [**CompositeSum**](./CompositeSum.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ CompositeSum**](./CompositeSum.md) **|** [**➡️ Constrain2D**](../Contrainte/Constrain2D.md) **|**

## **Descriptif**

Classe pour comportement composé et qui moyenne ses composants. Hérite de [CompositeSum](./CompositeSum.md)

## **Méthodes**

---

> public CompositeMean([Agent](../../Agent.md) proprietaire,List<[Comportement](../Base/Comportement.md)> c,List< int > i)

* param a : agent proprietaire du comportement
* param c : liste de comportement pour composer
* param i : liste des poids d'importances des comportements de la liste c
* return : instance de comportement

---

> public CompositeMean([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---
