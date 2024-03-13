// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement composé et additionnant
public class CompositeSum : Comportement
{

    // Attributs

    // liste des comportements qui compose notre comportement
    protected List<Comportement> comportements;
    // liste des poids d'importances des comportements
    protected List<int> importances;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire, une liste de comportement et une liste d'importance
    public CompositeSum(Agent proprietaire,List<Comportement> c,List<int> i) : base(proprietaire) {
        comportements = c;
        importances = i;
    }

    // Le comportement est construit par rapport à un proprietaire
    public CompositeSum(Agent proprietaire) : base(proprietaire) {
        comportements = new List<Comportement>();
        importances = new List<int>();
    }

    // enlève le ieme comportement de la liste des comportements
    public void removeComportement(int i) { comportements.RemoveAt(i);importances.RemoveAt(i); }

    // rajoute le comportement c avoir un poids d'importance i dans la liste des comportements 
    public void AddComportement(Comportement c, int i) { comportements.Add(c); importances.Add(i);}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        Vector3 res = Vector3.zero;
        Vector3 add;
        for(int i=0;i<comportements.Count;i++) {
            add = comportements[i].reagir(observation);
            for(int j=0; j<importances[i];j++) res += add;
        }
        return res;
    }

}
