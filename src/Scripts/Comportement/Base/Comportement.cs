// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe abstraite pour les comportements d'agent
public abstract class Comportement
{

    // Attributs

    // le proprietaire du comportement
    protected Agent proprietaire;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire
    public Comportement(Agent a) {
        proprietaire = a;
    }

    // retourne le vecteur déplacement en réaction aux observations
    public abstract Vector3 reagir(List<Observation> observation) ;

}
