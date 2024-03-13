// List
using System.Collections.Generic;
// GameObject + Vector3
using UnityEngine;

// Classe pour une topologie d'environnement en forme de carre
public class Carre : Cube
{

    // Méthodes

    // la topologie en carre se construit à partir du visuel du carre
    public Carre(Environnement e,GameObject c) : base(e,c) {
        minZ = 0.0f;maxZ = 0.0f;
    }

    
    // retourne le point de la topologie que l'agent current pourrait heurter
    public override Observation detectEnv(Agent current) {
        Vector3 side = goingToHit(current);
        side = convertToValidOne(side);
        Vector3 haut = new Vector3(0.0f,1.0f,0.0f);
        Vector3 droite = new Vector3(1.0f,0.0f,0.0f);
        List<Vector3> hauts = new List<Vector3> {haut,-haut};
        List<Vector3> droites = new List<Vector3> {droite,-droite};
        if (side.x == minX || side.x == maxX) 
            return new Observation(new PointObstacle(environnement,side,hauts),side-current.transform.position);
        else
            return new Observation(new PointObstacle(environnement,side,droites),side-current.transform.position);
    }

    // renvoie les projections de la position de l'agent current sur les côtés du carré
    protected List<Vector3> getExtremPositions(Agent current) {
        Vector3 pos = current.transform.position;
        List<Vector3> p = new List<Vector3>
        { 
            new Vector3(minX,pos.y,0.0f), new Vector3(maxX,pos.y,0.0f),
            new Vector3(pos.x,minY,0.0f), new Vector3(pos.x,maxY,0.0f)
        };
        return p;
    }

    // renvoie la position du point d'impact selon la direction unidirectionnel décrite par les composantes x, y et z 
    protected Vector3 basicAnswer(List<Vector3> p, float x, float y, float z) {
        if(x < 0.0f) return p[0];
        else if(x > 0.0f) return p[1];
        else if(y < 0.0f) return p[2];
        else return p[3];
    }

    // renvoie la position du point d'impact entre l'environnement et l'agent current 
    protected Vector3 goingToHit(Agent current) {

        Vector3 pos = current.transform.position;
        List<Vector3> p = getExtremPositions(current);

        float x = current.deplacement.x; float y = current.deplacement.y;float z = current.deplacement.z;
        Vector3 res = basicAnswer(p,x,y,z);
        if(onlyOneDirection(x,y,z)) return res;
        
        List<(Vector3,Vector3)> move = choiceMove(p,x,y,z);
        Vector3 adjacentPoint, deplacement, currentRes;

        Vector3 adjacent; float adjacentDist, angle, oppose;

        for (int i=0;i<move.Count;i++) {
            adjacentPoint = move[i].Item1;
            deplacement = move[i].Item2;
            adjacent = adjacentPoint-pos;
            adjacentDist = Utils.normVector(adjacent);
            angle = Vector3.Angle(current.deplacement,adjacent);
            oppose = (float) Utils.tan(angle) * adjacentDist;
            currentRes = adjacentPoint + deplacement * oppose;
            res = bestOne(current,currentRes,res);
        }

        return res;
    }

    // retourne les points des côtés ainsi que le déplacement trivial induit par le déplacement en x, y et z 
    protected List<(Vector3,Vector3)> choiceMove(List<Vector3> p, float x, float y,float z) {
        List<(Vector3,Vector3)> res = new List<(Vector3,Vector3)>();
        if (x > 0.0f && y > 0.0f) {
            res.Add((p[1],new Vector3(0.0f,1.0f,0.0f)));
            res.Add((p[3],new Vector3(1.0f,0.0f,0.0f)));
        }
        else if(x > 0.0f && y < 0.0f) {
            res.Add((p[1],new Vector3(0.0f,-1.0f,0.0f)));
            res.Add((p[2],new Vector3(1.0f,0.0f,0.0f)));
        }
        else if(x < 0.0f && y > 0.0f) {
            res.Add((p[0],new Vector3(0.0f,1.0f,0.0f)));
            res.Add((p[3],new Vector3(-1.0f,0.0f,0.0f)));
        }
        else {
            res.Add((p[0],new Vector3(0.0f,-1.0f,0.0f)));
            res.Add((p[2],new Vector3(-1.0f,0.0f,0.0f)));
        }
        return res;
    }
    
}
