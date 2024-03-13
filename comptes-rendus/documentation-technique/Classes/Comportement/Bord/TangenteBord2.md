# **| public class TangenteBord2 :** [**Bord**](./Bord.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ TangenteBord1**](./TangenteBord1.md) **|** [**➡️ CompositeSum**](../Composite/CompositeSum.md) **|**

## **Descriptif**

Classe pour comportement de gestion de Bord en Tangente 2eme version. Hérite de [TangenteBord1](TangenteBord1.md)

## **Attributs**

---
 
* public static float kT : constante de force tangente

---

## **Méthodes**

---

> public TangenteBord2([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---