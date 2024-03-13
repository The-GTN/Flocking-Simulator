# **| public class Perception |** [**↩️ Accueil**](../../doc.md) **|** [**⬅️ Observation**](../Vision/Observation.md) **|** [**➡️ Perception90**](./Perception90.md) **|**


## **Descriptif**

Classe correspondant à la perception d'un agent de son environnement

## **Attributs**

---

* protected [Agent](../Agent.md) proprietaire : L'agent propriétaire de la perception
* protected float rayon : Le rayon de vision
* protected float angle : l'angle de vision

---

## Méthodes

---

> public Perception([Agent](../Agent.md) agent, float r, float a)

* param agent : agent à qui la perception appartient
* param r : rayon de vision de la perception
* param a : angle de vision de la perception
* return : instance de la perception

---

> public List<[Observation](../Vision/Observation.md)> voir()

* return : la liste des observations que la perception a permis

---
