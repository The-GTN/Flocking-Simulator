# **| public class TangenteBord1 :** [**Bord**](./Bord.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Bord**](./Bord.md) **|** [**➡️ TangenteBord2**](./TangenteBord2.md) **|**


## **Descriptif**

Classe pour comportement de gestion de Bord en Tangente. Hérite de [Bord](Bord.md)

## **Méthodes**

---

> public TangenteBord1([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---
    
> protected virtual float deltaTan(Vector3 d)

* param d : distance de l'observation
* return : force de la réponse en tangente

---

> protected virtual Vector3 answerTan(Observation o)

* param o : observation effectuée
* return : le vecteur réponse en tangente à l'observation

---