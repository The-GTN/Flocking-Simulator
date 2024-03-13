// Vector3
using UnityEngine;

// Classe correspondant à une observation
public class Observation
{

    // attributs

    // Objet qui a été observé
    public Visible objet;

    // Le vecteur reliant l'observeur à l'observé
    public Vector3 distance;

    // méthodes

    // Une observation se construit à partir de l'observé et de la direction observeur-observé
    public Observation(Visible o, Vector3 d) {
        objet = o;
        distance = d;
    }

}
