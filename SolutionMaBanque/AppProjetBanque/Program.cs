using ClassLibrary;
Banque banque = new Banque("LCL", "Lyon");
banque.AjouterCompte(15763, "M. S", 50000, -1000);
banque.AjouterCompte(1000, "Mlle E", 1000, -1000);
banque.AjouterCompte(78640, "Mme Y", 100000, -1000);

Console.WriteLine(banque.ToString());
//banque.TriParIComparer();
banque.TriParPredicat();
Console.WriteLine(banque.ToString());

/*Console.WriteLine(banque.RendCompte(1000));

Console.WriteLine(banque.ToString());

Console.WriteLine(banque.PlusRiche());
Console.WriteLine(banque.CompteSup());
Console.WriteLine(banque.RendCompte(157630));

if (banque.Transferer(15763, 78640, 100000))
{
    Console.WriteLine("Transfert effectué");
}
else
{
    Console.WriteLine("Echec du transfert");
}
Console.WriteLine(banque.ToString());
*/
/*BanqueArrayList b = new BanqueArrayList("BNP", "Paris");
b.AjouterCompte(9876, "Mr A", 1000, -1000);
b.AjouterCompte(1234, "Ms B", 2000, -500);
b.AjouterCompte(4444, "Dr C", -100, -500);
Console.WriteLine(b.ToString());
b.TriParComparer();
Console.WriteLine(b.ToString());
*/