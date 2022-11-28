//GCost caculé en fonction distEuclidienne<distManhattan ainsi pour toute nos estimation 
//on devra prendre comme distance la distance euclidienne 

// Problème 1 : 

//Dans ce problème nous n'avons  pas le droit de tester la
//présence d’un marécage à une position donnée, notre heuristique 
//doit rester valable même si on change la zone marécageuse.

//Pour cela la détection de franchissement de marécage dans notre
//heuristique doit ce faire exclusivement grâce à la valuer de matrice[x,y]
//On doit alors créer un chemin passant par des coordonnées entière et 
//vérifier le type de case rencontrée

//Pour avoir un chemin de case entière on va prendre en distance de référence
//la distance de Manhattan entre 2 points.

//Distance Euclidienne entre PC et PF (un nombre de cases)
double distEuclidienne = DistReel(x, y, Form1.xfinal, Form1.yfinal);
double distAvecMarécages = DistAvecMarecage(x, y, distEuclidienne, Form1.xfinal, Form1.yfinal);
return distAvecMarécages;

