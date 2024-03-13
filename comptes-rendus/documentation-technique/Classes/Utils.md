# **| public class Utils |** [**↩️ Accueil**](../doc.md) **|** [**➡️ SMA**](./SMA.md) **|**

## **Descriptif**

Cette classe sert à répertorier les méthodes utiles aux autres classes. Il s'agit d'une "boîte à outils".

## **Méthodes**

---

> public static Vector3 randomDirection()

* return : un vecteur aleatoire normalisé

---

> public static Vector3 normalizedVector(float x, float y, float z)

* param x : mouvement en axe x
* param y : mouvement en axe y
* param z : mouvement en axe z
* return : un vecteur normalisé selon un mouvement en x, y et z

---

> public static Vector3 meanVector(List< Vector3 > vectors)

* param vectors : liste des vecteurs dont on souhaite faire la moyenne
* return : le vecteur moyennant la liste de vecteurs entrée en paramètre

---

> public static Vector3 randomVector(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)

* param minX : valeur minimale en x
* param maxX : valeur maximale en x
* param minY : valeur minimale en y
* param maxY : valeur maximale en y
* param minZ : valeur minimale en z
* param maxZ : valeur maximale en z
* return : un vecteur aleatoire avec des composantes x, y et z comprises respectivements entre minX et maxX, minY et maxY et minZ et maxZ

---

> public static float normVector(Vector3 v) 

* param v : le vecteur dont on veut retourner la norme
* return : la norme du vecteur v

---

> public static float normVector(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)

* param minX : valeur de départ du vecteur en x
* param maxX : valeur d'arrivée du vecteur en x
* param minY : valeur de départ du vecteur en y
* param maxY : valeur d'arrivée du vecteur en y
* param minZ : valeur de départ du vecteur en z
* param maxZ : valeur d'arrivée du vecteur en z
* return : la norme du vecteur décrit par les paramètres

---

> public static float abs(float n)

* param n : flottant dont on souhaite la valeur absolue
* return : la valeur absolue de n

---

> public static float pow(float n,int p)

* param n : le flottant qu'on souhaite élevé à une puissance p
* param p : puissance à laquelle on veut élever n
* return : n à la puissance p

---

> public static float random(float min, float max) 

* param min : valeur flottante minimale possible
* param max : valeur flottante maximale possible
* return : une valeur flottante entre min (inclus) et max (inclus)

---

> public static int random(int min, int max)

* param min : valeur entière minimale possible
* param max : valeur entière maximale possible
* return : une valeur entière entre min (inclus) et max (exclus)

---

> public static float randomPosOrNeg(float n)

* param n : le flottant qu'on souhaite aléatoirement rendre négatif ou positif
* return : le flottant n aléatoirement rendu négatif ou positif

---

> public static int randomPosOrNeg(int n)

* param n : l'entier qu'on souhaite aléatoirement rendre négatif ou positif
* return : l'entier n aléatoirement rendu négatif ou positif

---

> public static float tan(float angle) 

* param angle : l'angle dont on souhaite la tangente
* return : la tangente de l'angle

---