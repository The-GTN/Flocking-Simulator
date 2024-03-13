// Vector3
using UnityEngine;
//List
using System.Collections.Generic;

// Classe pour les objets obstacles (environnement ou objet)
public abstract class Obstacle : Visible
{

    // Attributs

    // position de l'objet
    public Vector3 position;
    // environnement de l'objet
    protected Environnement env;

    // Méthodes

    // indique s'il est un Visible mobile
    public bool isAlive() { return false; }

    // l'obstacle est défini par sa position
    public Obstacle(Environnement e, Vector3 p) {
        env = e;
        position = p;
    }

    // retourne le point de contact en l'Agent a et l'obstacle
    public abstract Vector3 getPointContact(Agent a);

    // retourne les deux tangentes au point d'impact entre l'agent et l'obstacle
    public abstract List<Vector3> getTangentes(Agent a);

    // créer l'objet 3D relatif à cet obstacle
    public abstract void createObject(); 
}
