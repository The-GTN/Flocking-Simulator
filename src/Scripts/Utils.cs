// Vector3
using UnityEngine;
// Math
using System;
// List
using System.Collections.Generic;

// Classe contenant des méthodes utiles à toutes les autres classes
public class Utils
{

    // Méthodes

    // renvoie un vecteur aleatoire normalisé
    public static Vector3 randomDirection() {

        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        int r;
        for(int i = 0; i<10; i++) {
            r = random(0,3);
            if (r == 0) x += 1.0f;
            else if (r == 1) y += 1.0f;
            else z += 1.0f;
        }
        x = randomPosOrNeg(x);
        y = randomPosOrNeg(y);
        z = randomPosOrNeg(z);

        return normalizedVector(x,y,z);
    }

    // retourne un vecteur normalisé selon un mouvement en x, y et z
    public static Vector3 normalizedVector(float x, float y, float z) {
        return (new Vector3(x,y,z)).normalized;
    }

    // renvoie le vecteur moyennant la liste de vecteurs entrée en paramètre
    public static Vector3 meanVector(List<Vector3> vectors) {
        Vector3 res = Vector3.zero;
        for(int i = 0; i<vectors.Count; i++) {
            res += vectors[i];
        }
        if(vectors.Count != 0) res = res/vectors.Count;
        return res;
    }

    // renvoie un vecteur aleatoire avec des composantes x, y et z comprises respectivements entre minX et maxX, minY et maxY et minZ et maxZ
    public static Vector3 randomVector(float minX, float maxX, float minY, float maxY, float minZ, float maxZ) {
        return new Vector3(random(minX,maxX),
                            random(minY,maxY),
                            random(minZ,maxZ));
    }

    // renvoie la norme d'un vecteur
    public static float normVector(Vector3 v) {
        return (float) Math.Sqrt(Math.Pow(v.x,2) + Math.Pow(v.y,2) + Math.Pow(v.z,2));
    }

    // renvoie la norme d'un vecteur allant d'un point aux coordonnées (minX,minY,minZ) jusqu'à un point aux coordonnées (maxX,maxY,maxZ)  
    public static float normVector(float minX, float maxX, float minY, float maxY, float minZ, float maxZ) {
        return (float) Math.Sqrt(Math.Pow(maxX-minX,2) + Math.Pow(maxY-minY,2) + Math.Pow(maxZ-minZ,2));
    }

    // renvoie la valeur absolue du flottant n
    public static float abs(float n) {return (float) Math.Sqrt(Math.Pow(n,2));}

    // renvoie le flottant n à la puissance p
    public static float pow(float n,int p) {return (float) Math.Pow(n,p);}

    // renvoie un flottant aléatoire entre min (inclus) et max (inclus) 
    public static float random(float min, float max) {return UnityEngine.Random.Range(min,max);} 
    
    // renvoie un entier aléatoire entre min (inclus) et max (exclus) 
    public static int random(int min, int max) {return UnityEngine.Random.Range(min,max);}

    // renvoie un flottant n aléatoirement positif ou négatif
    public static float randomPosOrNeg(float n) { return n * ((float) Math.Pow(-1,random(0,2)));  }

    // renvoie un entier n aléatoirement positif ou négatif
    public static int randomPosOrNeg(int n) { return n * ((int) Math.Pow(-1,random(0,2)));  }

    // renvoie la tangente de l'angle angle
    public static float tan(float angle) {return (float) Math.Tan(angle);}

}
